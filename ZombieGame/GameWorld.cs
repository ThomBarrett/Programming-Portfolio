using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class GameWorld
    {
        /// <summary>
        /// SizeX of the world
        /// </summary>
        private int sizeX;
        
        /// <summary>
        /// SizeY of the world
        /// </summary>
        private int sizeY;

        /// <summary>
        /// Represents the players position in the gameworld.
        /// </summary>
        private Coord playerPosition;

        /// <summary>
        /// How much space is between the player and the border X Axies.
        /// </summary>
        private int offsetX = 10;

        /// <summary>
        /// How much space is between the player and the border Y Axies.
        /// </summary>
        private int offsetY = 10;

        private int maxEnemies = 50;

        /// <summary>
        /// Stores all current active zombies in the world and their locations.
        /// </summary>
        private Dictionary<Coord, Zombie> zombies = new Dictionary<Coord, Zombie>();

        /// <summary>
        /// Represents a 2D map of various Locations. 
        /// First Layer.
        /// <see cref="ZombieGame.Location"/>
        /// </summary>
        private Location[,] locationLayer;

        /// <summary>
        /// Represents a 2D map of various Items. 
        /// Second Layer.
        /// <see cref="ZombieGame.Item"/>
        /// </summary>
        private Item[,] itemLayer;

        /// <summary>
        /// Represents a 2D map of various Entities. 
        /// Third Layer.
        /// <see cref="ZombieGame.Entity"/>
        /// </summary>
        private Entity[,] entityLayer;

        /// <summary>
        /// Creates a gameworld which consists of layers:
        ///     1 Location Layer <see cref="locationLayer"/>
        ///     2 Item Layer <see cref="itemLayer"/>
        ///     3 Entity Layer <see cref="entityLayer"/>
        /// </summary>
        /// <param name="gameExists">
        /// This param tests if there is a game that already existing
        /// and if there isn't it creates one.
        /// </param>
        public GameWorld(bool gameExists)
        {
            if (gameExists)
            {
               
            }
            else
            {
                SelectSize();
                GenerateAll();

                while (true)
                {
                    Display(playerPosition);
                    Input();
                    StartZombiesTurn();
                }
            }
        }

        /// <summary>
        /// Brings up a UI allowing you to select a size: 
        /// <see cref="WorldSize.SMALL"/>, <see cref="WorldSize.MEDIUM"/>, <see cref="WorldSize.LARGE"/>
        /// </summary>
        private void SelectSize()
        {
            Console.Clear();
            Console.Out.WriteLine(" ╔════════════════╗");
            Console.Out.WriteLine(" ║ Select A Size: ║");
            Console.Out.Write(" ╠");

            for (int i = 0; i < 116; i++)
            {
                if (i == 16)
                {
                    Console.Write("╩");
                }
                else
                {
                    Console.Write("═");
                }
            }

            Console.Out.WriteLine("╗");

            Console.Out.Write(" ║");
            for (int i = 0; i < 116; i++)
            {
                Console.Write(" ");
            }

            Console.Out.WriteLine("║");

            Console.Out.WriteLine(" ║ (1)Small                                             (2)Medium                                            (3)Large ║");

            Console.Out.Write(" ║");
            for (int i = 0; i < 116; i++)
            {
                Console.Write(" ");
            }

            Console.Out.WriteLine("║");

            Console.Out.Write(" ╚");

            for (int i = 0; i < 116; i++)
            {
                Console.Write("═");
            }

            Console.Out.WriteLine("╝");
            Console.Out.Write(" > ");

            string input = Console.In.ReadLine();
            Console.In.Close();
            SoundSystem.PlayEnterSound();
            Console.Clear();

            switch (input)
            {
                case "1":
                    GenerateSize(WorldSize.SMALL);
                    break;

                case "2":
                    GenerateSize(WorldSize.MEDIUM);
                    break;

                case "3":
                    GenerateSize(WorldSize.LARGE);
                    break;

                default:
                    SelectSize();
                    return;

            }

        }

        /// <summary>
        /// Creates an entirely empty world consisting of 3 layers
        /// </summary>
        /// <param name="worldSize">
        /// This param control how large the world be will created.
        /// </param>
        private void GenerateSize(WorldSize worldSize)
        {
            switch (worldSize)
            {
                case WorldSize.SMALL:
                    locationLayer = new Location[sizeY = 100, sizeX = 100];
                    itemLayer = new Item[sizeY, sizeX];
                    entityLayer = new Entity[sizeY, sizeX];
                    break;

                case WorldSize.MEDIUM:
                    locationLayer = new Location[sizeY = 500, sizeX = 500];
                    itemLayer = new Item[sizeY, sizeX];
                    entityLayer = new Entity[sizeY, sizeX];
                    break;

                case WorldSize.LARGE:
                    locationLayer = new Location[sizeY = 1000, sizeX = 1000];
                    itemLayer = new Item[sizeY, sizeX];
                    entityLayer = new Entity[sizeY, sizeX];
                    break;

                default:
                    throw new IllegialStateException("No size specified");
                    
            }
        }

        /// <summary>
        /// Calls all the Generation Methods associated with GameWorld
        /// <see cref="GenerateLocations()"/>
        /// <see cref="GenerateItem()"/>
        /// <see cref="GenerateEntities()"/>
        /// </summary>
        private void GenerateAll()
        {
            GenerateLocations();
            GenerateItems();
            GenerateEntities();
        }

        /// <summary>
        /// Generates all the Terrain: 
        /// <see cref="Plain"/>, 
        /// <see cref="Grass"/>, 
        /// <see cref="Water"/>, 
        /// <see cref="WaterEdge"/>,
        /// etc...
        /// </summary>
        private void GenerateLocations()
        {
            Random random = new Random();
            //Base Ground
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    int seed = random.Next(500);

                    if (seed < 150)
                    {
                        locationLayer[y, x] = new Plain();
                    }
                    else
                    {
                        locationLayer[y, x] = new Grass();
                    }
                }
            }

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (random.Next(100) < 6)
                    {
                        if (y - 1 > -1)
                        {
                            locationLayer[y - 1, x] = new Water();
                        }

                        if (x - 1 > -1)
                        {
                            locationLayer[y, x - 1] = new WaterEdge();
                        }

                        if (y + 1 < sizeY)
                        {
                            locationLayer[y + 1, x] = new WaterEdge();
                        }

                        if (x + 1 < sizeX)
                        {
                            locationLayer[y, x + 1] = new Water();
                        }

                        locationLayer[y, x] = new Water();

                    }
                }
            }
        }

        /// <summary>
        /// Generates Interactive Items into the Gameworld 
        /// <see cref="Rock"/>, 
        /// <see cref="Tree"/>, etc...
        /// </summary>
        private void GenerateItems()
        {
            Random rand = new Random();
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    int seed = rand.Next(20);
                    if (locationLayer[y, x].GetType().Equals("Grass") && seed < 10)
                    {
                        seed = rand.Next(10);
                        if (seed < 6)
                        {
                            itemLayer[y, x] = new Tree(x, y);
                        }
                        else
                        {
                            itemLayer[y, x] = new Rock(x, y);
                        }
                    }
                    else
                    {
                        itemLayer[y, x] = new EmptyItem();
                    }

                }
            }
        }

        /// <summary>
        /// Generates Entities like Player, Enemies and NPCs  
        /// </summary>
        private void GenerateEntities()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    entityLayer[y, x] = new EmptyEntity();
                }
            }
            playerPosition = new Coord(10, 10);
            
            entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.y, playerPosition.x, Direction.UP);

            Random rand = new Random();

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (rand.Next(1, 101) < 2)
                    {
                        Coord coord = new Coord(x, y);
                        Zombie zombie = new Zombie(coord.x, coord.y);
                        entityLayer[y, x] = zombie;

                        zombies.Add(coord, zombie);
                    }
                }
            }

        }

        /// <summary>
        /// Find out what key the player is pressing
        /// if any and make sure the player doesn't enter wrong button presses
        /// </summary>
        private void Input()
        {

            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                //Directional Keys
                case ConsoleKey.UpArrow:
                    break;

                case ConsoleKey.DownArrow:
                    break;

                case ConsoleKey.LeftArrow:
                    break;

                case ConsoleKey.RightArrow:
                    break;

                case ConsoleKey.A:
                    break;

                case ConsoleKey.Tab:
                    SoundSystem.PlayEnterSound();
                    break;

                case ConsoleKey.Escape:
                    SoundSystem.PlayEnterSound();
                    break;

                case ConsoleKey.D0:
                    PlayerInformation.HotbarSlotSet(9);
                    break;

                case ConsoleKey.D1:
                    PlayerInformation.HotbarSlotSet(0);
                    break;

                case ConsoleKey.D2:
                    PlayerInformation.HotbarSlotSet(1);
                    break;

                case ConsoleKey.D3:
                    PlayerInformation.HotbarSlotSet(2);
                    break;

                case ConsoleKey.D4:
                    PlayerInformation.HotbarSlotSet(3);
                    break;

                case ConsoleKey.D5:
                    PlayerInformation.HotbarSlotSet(4);
                    break;

                case ConsoleKey.D6:
                    PlayerInformation.HotbarSlotSet(5);
                    break;

                case ConsoleKey.D7:
                    PlayerInformation.HotbarSlotSet(6);
                    break;

                case ConsoleKey.D8:
                    PlayerInformation.HotbarSlotSet(7);
                    break;

                case ConsoleKey.D9:
                    PlayerInformation.HotbarSlotSet(8);
                    break;

                default:
                    Input();
                    break;
            }
            Update(keyInfo.Key);
        }

        /// <summary>
        /// Run Calculations based on what the user pressed during the exection of <c>GameWorld.Input</c>
        /// </summary>
        /// <param name="keyPressed">
        /// Keystoke used to work out what calculation are required.
        /// </param>
        private void Update(ConsoleKey keyPressed)
        {
            IsDirectionalPressed(keyPressed);
            IsAPressed(keyPressed);
            IsTabPressed(keyPressed);
            IsEscapePressed(keyPressed);
        }

        /// <summary>
        /// Handles the players movement around the Gameworld.
        /// </summary>
        /// <param name="keyPressed">
        /// This param is used to decide how the player should move
        /// if at all.
        /// </param>
        private void IsDirectionalPressed(ConsoleKey keyPressed)
        {
            Player player = (Player)entityLayer[playerPosition.y, playerPosition.x];
            if (keyPressed.Equals(ConsoleKey.UpArrow) && player.GetDirection().Equals(Direction.UP))
            {

                if (playerPosition.y != 0)
                {
                    if (entityLayer[playerPosition.y - 1, playerPosition.x].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerPosition.y, playerPosition.x] = new EmptyEntity();

                        playerPosition.y--;

                        entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.UP);
                    }
                }
                else
                {
                    Input();
                }

            }
            else if (keyPressed.Equals(ConsoleKey.UpArrow) && !player.GetDirection().Equals(Direction.UP))
            {
                entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.UP);
            }

            if (keyPressed.Equals(ConsoleKey.DownArrow) && player.GetDirection().Equals(Direction.DOWN))
            {
                if (playerPosition.y != sizeY - 1)
                {
                    if (entityLayer[playerPosition.y + 1, playerPosition.x].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerPosition.y, playerPosition.x] = new EmptyEntity();

                        playerPosition.y++;

                        entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.DOWN);
                    }
                }
                else
                {
                    Input();
                }
            }
            else if (keyPressed.Equals(ConsoleKey.DownArrow) && !player.GetDirection().Equals(Direction.DOWN))
            {
                entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.DOWN);
            }

            if (keyPressed.Equals(ConsoleKey.LeftArrow) && player.GetDirection().Equals(Direction.LEFT))
            {
                if (playerPosition.x != 0)
                {
                    if (entityLayer[playerPosition.y, playerPosition.x - 1].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerPosition.y, playerPosition.x] = new EmptyEntity();

                        playerPosition.x--;

                        entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.LEFT);
                    }
                }
                else
                {
                    Input();
                }
            }
            else if (keyPressed.Equals(ConsoleKey.LeftArrow) && !player.GetDirection().Equals(Direction.LEFT))
            {
                entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.LEFT);
            }

            if (keyPressed.Equals(ConsoleKey.RightArrow) && player.GetDirection().Equals(Direction.RIGHT))
            {
                if (playerPosition.x != sizeX - 1)
                {
                    if (entityLayer[playerPosition.y, playerPosition.x + 1].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerPosition.y, playerPosition.x] = new EmptyEntity();

                        playerPosition.x++;

                        entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.RIGHT);
                    }
                }
                else
                {
                    Input();
                }
            }
            else if (keyPressed.Equals(ConsoleKey.RightArrow) && !player.GetDirection().Equals(Direction.RIGHT))
            {
                entityLayer[playerPosition.y, playerPosition.x] = new Player(playerPosition.x, playerPosition.y, Direction.RIGHT);
            }
        }

        /// <summary>
        /// Test if interaction key is pressed and how it should affect the world.
        /// </summary>
        /// <param name="keyPressed">
        /// Key used to work out how the player should interact with the surrondings.
        /// </param>
        private void IsAPressed(ConsoleKey keyPressed)
        {
            Player player = (Player)entityLayer[playerPosition.y, playerPosition.x];
            if (keyPressed.Equals(ConsoleKey.A))
            {
                if (player.GetDirection().Equals(Direction.UP))
                {
                    if (!(playerPosition.y - 1 < 0))
                    {
                        CollectItem(itemLayer[playerPosition.y - 1, playerPosition.x].GetType().Name.ToString());
                        itemLayer[playerPosition.y - 1, playerPosition.x] = new EmptyItem();
                    }
                }

                if (player.GetDirection().Equals(Direction.DOWN))
                {
                    if (!(playerPosition.y > sizeY - 1))
                    {
                        CollectItem(itemLayer[playerPosition.y + 1, playerPosition.x].GetType().Name.ToString());
                        itemLayer[playerPosition.y + 1, playerPosition.x] = new EmptyItem();
                    }
                }

                if (player.GetDirection().Equals(Direction.LEFT))
                {
                    if (!(playerPosition.x - 1 < 0))
                    {
                        CollectItem(itemLayer[playerPosition.y, playerPosition.x - 1].GetType().Name.ToString());
                        itemLayer[playerPosition.y, playerPosition.x - 1] = new EmptyItem();
                    }
                }

                if (player.GetDirection().Equals(Direction.RIGHT))
                {
                    if (!(playerPosition.x > sizeX - 1))
                    {
                        CollectItem(itemLayer[playerPosition.y, playerPosition.x + 1].GetType().Name.ToString());
                        itemLayer[playerPosition.y, playerPosition.x + 1] = new EmptyItem();
                    }
                }
            }
        }

        /// <summary>
        /// Opens menu if criteria is met.
        /// </summary>
        /// <param name="keyPressed">
        /// If tab key is pressed open menu.
        /// </param>
        private void IsTabPressed(ConsoleKey keyPressed)
        {
            if (keyPressed.Equals(ConsoleKey.Tab))
            {
                Console.Clear();
                PlayerInformation.DisplayGameMenu();
            }
        }

        /// <summary>
        /// Opens Exit menu if criteria is met
        /// </summary>
        /// <param name="keyPressed">
        /// If tab key is pressed open Exit menu
        /// </param>
        private void IsEscapePressed(ConsoleKey keyPressed)
        {
            if (keyPressed.Equals(ConsoleKey.Escape))
            {
                DisplayExitMenu();
            }
        }

        /// <summary>
        /// If player tries to pick up a item this method is used to see how many should be pick up.
        /// </summary>
        /// <param name="itemName">
        /// This will be the item that the player will be collecting.
        /// </param>
        private void CollectItem(String itemName)
        {
            int multiplier = 1;

            if (PlayerInformation.CheckCurrentSlot("StoneAxe"))
            {
                multiplier = 5;
            }

            switch (itemName)
            {
                case "Tree":
                    PlayerInformation.AddItem(0, new Wood(1 * multiplier));
                    break;

                case "Rock":
                    PlayerInformation.AddItem(1, new Stone(1 * multiplier));
                    break;
            }
        }

        /// <summary>
        /// For every zombie in the world go through them all making sure they make their turns
        /// </summary>
        private void StartZombiesTurn()
        {
            for (int i = 0; i < zombies.Count; i++)
            {
                KeyValuePair<Coord, Zombie> kv = zombies.ElementAt(i);
                ZombieTurn(kv.Key);
            }
        }

        /// <summary>
        /// Individual zombies turn. Calls Alert, Hunning or Stunned turn based of zombie state.
        /// </summary>
        /// <param name="coord">
        /// The position of the zombie that should take it's turn
        /// </param>
        private void ZombieTurn(Coord coord)
        {
            if (entityLayer[coord.y, coord.x].GetType().Name == "EmptyEntity")
            {
                return;
            }

            Zombie current = (Zombie)entityLayer[coord.y, coord.x];
            CheckIfHunting(current.position);

            switch (current.GetState())
            {
                case ZombieState.ALERT:
                    AlertTurn(coord);
                    break;
                case ZombieState.HUNTING:
                    HuntingTurn(coord);
                    break;
                case ZombieState.STUNNED:
                    break;
            }
        }

        /// <summary>
        /// If player is at a certain range then hunting mode should be turned on
        /// </summary>
        /// <param name="coord"></param>
        private void CheckIfHunting(Coord coord)
        {
            uint x = 0, y = 0;
            //Min X
            if(coord.x >= 2){
                x = coord.x - 2;
            }
            else if(coord.x == 1)
            {
                x = coord.x - 1;
            }
            else if(coord.x == 0)
            {
                x = coord.x;
            }
            //Min Y
            if (coord.y >= 2)
            {
                y = coord.y - 2;
            }
            else if (coord.y == 1)
            {
                y = coord.y - 1;
            }
            else if (coord.y == 0)
            {
                y = coord.y;
            }

            Coord minBound = new Coord(x, y);

            //MAX X
            if (coord.x == sizeX - 1)
            {
                x = coord.x;
            }
            else if (coord.x == sizeX - 2)
            {
                x = coord.x + 1;
            }
            else if (coord.x <= sizeX - 3)
            {
                x = coord.x + 2;
            }

            if (coord.y == sizeY - 1)
            {
                y = coord.y;
            }
            else if (coord.y == sizeY - 2)
            {
                y = coord.y + 1;
            }
            else if (coord.y <= sizeY - 3)
            {
                y = coord.y + 2;
            }

            Coord maxBound = new Coord(x, y);

            if(playerPosition.x >= minBound.x && playerPosition.y <= maxBound.x)
            {
                if (playerPosition.y >= minBound.y && playerPosition.y <= maxBound.y)
                {
                    Zombie zombie = (Zombie)entityLayer[coord.y, coord.x];
                    zombie.ToHunting();
                    entityLayer[coord.y, coord.x] = zombie;
                }
                else
                {
                    Zombie zombie = (Zombie)entityLayer[coord.y, coord.x];
                    zombie.ToAlert();
                    entityLayer[coord.y, coord.x] = zombie;
                }
            }
            else
            {
                Zombie zombie = (Zombie)entityLayer[coord.y, coord.x];
                zombie.ToAlert();
                entityLayer[coord.y, coord.x] = zombie;
            }
        }

        /// <summary>
        /// This function carries out the procedure for a Alert Zombie turn
        /// Random movement
        /// </summary>
        /// <param name="oldCoord">
        /// Old zombie position used to calcalate new positions to move too
        /// </param>
        private void AlertTurn(Coord oldCoord)
        {
            Random rand = new Random();

            int gen = rand.Next(0, 5);
            Coord newCoord = oldCoord;
            switch (gen)
            {
                case 0:
                    //DO NOTHING
                    break;
                case 1:
                    //UP
                    if (oldCoord.y != 0)
                    {
                        newCoord = new Coord(oldCoord.x, oldCoord.y - 1);
                    }
                    break;
                case 2:
                    //RIGHT
                    if (oldCoord.x != sizeX - 1)
                    {
                        newCoord = new Coord(oldCoord.x + 1, oldCoord.y);
                    }
                    break;
                case 3:
                    //DOWN
                    if (oldCoord.y != sizeY - 1)
                    {
                        newCoord = new Coord(oldCoord.x, oldCoord.y + 1);
                    }
                    break;
                case 4:
                    if (oldCoord.x != 0)
                    {
                        newCoord = new Coord(oldCoord.x - 1, oldCoord.y);
                    }
                    //LEFT
                    break;
            }

            if (gen != 0)
            {
                ZombieMove(oldCoord, newCoord);
            }
        }

        /// <summary>
        /// Seeks out the player and moves towards players position in gameworld
        /// </summary>
        /// <param name="oldCoord">
        /// Old zombie position used to calculate new position in gameworld
        /// </param>
        private void HuntingTurn(Coord oldCoord)
        {
            Random rand = new Random();

            int gen = rand.Next(0, 2);

            if (gen.Equals(0))
            {
                Coord newCoord;
                if (oldCoord.x < playerPosition.x)
                {
                    newCoord = new Coord(oldCoord.x + 1, oldCoord.y);
                }
                else
                {
                    newCoord = new Coord(oldCoord.x - 1, oldCoord.y);
                }
                ZombieMove(oldCoord, newCoord);
            }
            else
            {
                Coord newCoord;
                if (oldCoord.y < playerPosition.y)
                {
                    newCoord = new Coord(oldCoord.x, oldCoord.y + 1);
                }
                else
                {
                    newCoord = new Coord(oldCoord.x, oldCoord.y - 1);
                }
                ZombieMove(oldCoord, newCoord);
            }

        }

        /// <summary>
        /// Skips zombies turn and player can do bonus damage
        /// </summary>
        private void StunnedTurn()
        {

        }

        /// <summary>
        /// Calcuate if zombie can move into space.
        /// If space is empty then it can if space contains player then the player gets attacked
        /// </summary>
        /// <param name="oldCoord">
        /// Old position used to reference the zombie
        /// </param>
        /// <param name="newCoord">
        /// Where the zombie tries to move to
        /// </param>
        private void ZombieMove(Coord oldCoord, Coord newCoord)
        {
            Zombie currentZombie = (Zombie)entityLayer[oldCoord.y, oldCoord.x];
            if (entityLayer[newCoord.y, newCoord.x].GetType().Name == "EmptyEntity")
            {
                int HP = currentZombie.GetHP();
                ZombieState state = currentZombie.GetState();
                entityLayer[oldCoord.y, oldCoord.x] = new EmptyEntity();
                zombies.Remove(oldCoord);
                entityLayer[newCoord.y, newCoord.x] = new Zombie(newCoord.x, newCoord.y, HP, state);
                zombies.Add(newCoord, new Zombie(newCoord.x, newCoord.y));
                return;
            }
            else if (entityLayer[newCoord.y, newCoord.x].GetType().Name == "Player")
            {
                ZombieAttack();
            }
        }

        /// <summary>
        /// Plays bite sound then minuses HP points from player
        /// </summary>
        private void ZombieAttack()
        {
            SoundSystem.PlayBiteSound();
            PlayerInformation.HealthMinus(5);
        }

        /// <summary>
        /// Used to display the Gameworld and display the correct layers at the correct situations.
        /// </summary>
        [Obsolete("Use Display(Coord playerPosition) instead",true)]
        private void Display()
        {
            Console.Clear();
            for (int y = 0; y < sizeY; y++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Out.Write("         ");
                for (int x = 0; x < sizeX; x++)
                {

                    DrawCorrectLayer(x, y);

                }
                Console.Out.WriteLine();
            }
        }

        /// <summary>
        /// Displays a scrolling gameworld with the player in the certain.
        /// It works out what layer it should be displaying in what situations.
        /// </summary>
        /// <param name="playerPosition"></param>
        private void Display(Coord playerPosition)
        {
            Console.Clear();

            Console.Out.WriteLine();
            Console.Out.Write("  ");
            PlayerInformation.DisplayHealthBar();

            ApplyFormating();
            for (int y = (int)playerPosition.y - offsetY; y < playerPosition.y + offsetY; y++)
            {
                Console.BackgroundColor = ConsoleColor.Black;

                for (int x = (int)playerPosition.x - offsetX; x < playerPosition.x + offsetX; x++)
                {

                    DrawCorrectLayer(x, y);

                }
                ApplyFormating();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            PlayerInformation.DisplayHotbar();
            Console.WriteLine();
        }

        /// <summary>
        /// Used to Format the Display Method to make present how it should
        /// </summary>
        private void ApplyFormating()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.Write("     ");
        }

        /// <summary>
        /// This method works out what layer it should be displaying at a X Y Coordinate
        /// </summary>
        /// <param name="x">
        /// Where to manipulate on the X Axies.
        /// </param>
        /// <param name="y">
        /// Where to manipulate on the Y Axies.
        /// </param>
        private void DrawCorrectLayer(int x, int y)
        {

            if (!IsSafePlace(x, y))
            {
                return;
            }

            if (!entityLayer[y, x].GetType().Name.Equals("EmptyEntity"))
            {
                entityLayer[y, x].Display(locationLayer[y, x].GetDisplayable().GetColor());
                return;
            }
            else if (!itemLayer[y, x].GetType().Name.Equals("EmptyItem"))
            {
                if (itemLayer[y, x].GetDisplayable().TrueOrFalse())
                {

                    itemLayer[y, x].GetDisplayable().Display(locationLayer[y, x].GetDisplayable().GetColor());
                    return;

                }

            }
            else
            {
                locationLayer[y, x].GetDisplayable().Display();
                return;

            }
        }

        /// <summary>
        /// Makes sure cell we are trying to access is in bounds of Gameword layer arrays
        /// </summary>
        /// <param name="x">
        /// X Position
        /// </param>
        /// <param name="y">
        /// Y Position
        /// </param>
        /// <returns></returns>
        private bool IsSafePlace(int x, int y)
        {
            if (x < 0 || x > sizeX - 1)
            {
                return false;
            }
            if (y < 0 || y > sizeY - 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Display the exit menu and then prompt the user to make a choice.
        /// 1: Exit, 
        /// 2: Return,
        /// AnythingElse: Recall it's self.
        /// </summary>
        private void DisplayExitMenu()
        {

            Console.Clear();
            Console.Out.WriteLine(" ╔═══════╗");
            Console.Out.WriteLine(" ║ Quit? ║");
            Console.Out.Write(" ╠");

            for (int i = 0; i < 116; i++)
            {
                if (i == 7)
                {
                    Console.Write("╩");
                }
                else
                {
                    Console.Write("═");
                }
            }

            Console.Out.WriteLine("╗");

            Console.Out.Write(" ║");
            for (int i = 0; i < 116; i++)
            {
                Console.Write(" ");
            }

            Console.Out.WriteLine("║");

            Console.Out.WriteLine(" ║          (1)Yes                                                                                     (2)No          ║");

            Console.Out.Write(" ║");
            for (int i = 0; i < 116; i++)
            {
                Console.Write(" ");
            }

            Console.Out.WriteLine("║");

            Console.Out.Write(" ╚");

            for (int i = 0; i < 116; i++)
            {
                Console.Write("═");
            }

            Console.Out.WriteLine("╝");
            Console.Out.Write(" > ");

            string input = Console.In.ReadLine();
            Console.In.Close();

            if (input.Equals("1"))
            {
                System.Environment.Exit(0);
            }
            else if (input.Equals("2"))
            {
                return;
            }
            else
            {
                DisplayExitMenu();
            }
        }
    }
}
