using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class GameWorld
    {
        private int sizeX;
        private int sizeY;
        private Coord playerPosition;

        private int offsetX = 10;
        private int offsetY = 10;

        private int maxEnemies = 50;

        /// <summary>
        /// Stores all current active zombies in the world and their locations.
        /// </summary>
        private Dictionary<Coord, Zombie> zombies = new Dictionary<Coord, Zombie>();

        /// <summary>
        /// Represents a 2D map of various Locations <see cref="ZombieGame.Location"/>
        /// First Layer.
        /// </summary>
        private Location[,] locationLayer;

        /// <summary>
        /// Represents a 2D map of various Items <see cref="ZombieGame.Item"/>
        /// Second Layer.
        /// </summary>
        private Item[,] itemLayer;

        /// <summary>
        /// Represents a 2D map of various Entities <see cref="ZombieGame.Entity"/>
        /// Third Layer.
        /// </summary>
        private Entity[,] entityLayer;


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

        private void GenerateAll()
        {
            GenerateLocations();
            GenerateItems();
            GenerateEntities();
        }

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

        private void Update(ConsoleKey keyPressed)
        {

            IsDirectionalPressed(keyPressed);
            IsAPressed(keyPressed);
            IsTabPressed(keyPressed);
            IsEscapePressed(keyPressed);
        }

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

        private void IsTabPressed(ConsoleKey keyPressed)
        {
            if (keyPressed.Equals(ConsoleKey.Tab))
            {
                Console.Clear();
                PlayerInformation.DisplayGameMenu();
            }
        }

        private void IsEscapePressed(ConsoleKey keyPressed)
        {
            if (keyPressed.Equals(ConsoleKey.Escape))
            {
                DisplayExitMenu();
            }
        }

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

        private void StartZombiesTurn()
        {
            for (int i = 0; i < zombies.Count; i++)
            {
                KeyValuePair<Coord, Zombie> kv = zombies.ElementAt(i);
                ZombieTurn(kv.Key);
            }
        }

        private void ZombieTurn(Coord coord)
        {
            if (entityLayer[coord.y, coord.x].GetType().Name == "EmptyEntity")
            {
                return;
            }

            Zombie current = (Zombie)entityLayer[coord.y, coord.x];

            switch (current.GetState())
            {
                case ZombieState.ALERT:
                    AlertTurn(coord);
                    break;
                case ZombieState.HUNTING:
                    break;
                case ZombieState.STUNNED:
                    break;
            }
        }

        private void CheckIfHunting(Coord coord)
        {
            
        }

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

        private void ZombieAttack()
        {
            SoundSystem.PlayBiteSound();
            PlayerInformation.HealthMinus(5);
        }

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

        private void ApplyFormating()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.Write("     ");
        }

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
