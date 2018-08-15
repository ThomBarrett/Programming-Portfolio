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

        private int playerX, playerY;

        private int offsetX = 10;
        private int offsetY = 10;

        private int maxEnemies = 50;
        private int currentEnemies;

        private Location[,] locationLayer;
        private Item[,] itemLayer;
        private Entity[,] entityLayer;


        public GameWorld(bool gameExists)
        {
            if (gameExists)
            {

            }
            else
            {
                SelectSize();
                GenerateLocations();
                GenerateItems();
                GenerateEntities();

                while (true)
                {
                    Display(playerX, playerY);
                    Input();
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
            entityLayer[playerY = 10, playerX = 10] = new Player(playerY, playerX, Direction.UP);

            Random rand = new Random();

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if(rand.Next(1,101) < 2)
                    {
                        entityLayer[y, x] = new Zombie();

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
            Player player = (Player)entityLayer[playerY, playerX];
            if (keyPressed.Equals(ConsoleKey.UpArrow) && player.GetDirection().Equals(Direction.UP))
            {

                if (playerY != 0)
                {
                    if (entityLayer[playerY - 1, playerX].GetType().Name.Equals("EmptyEntity")){
                        entityLayer[playerY, playerX] = new EmptyEntity();

                        playerY--;

                        entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.UP);
                    }
                }
                else
                {
                    Input();
                }

            }
            else if (keyPressed.Equals(ConsoleKey.UpArrow) && !player.GetDirection().Equals(Direction.UP))
            {
                entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.UP);
            }

            if (keyPressed.Equals(ConsoleKey.DownArrow) && player.GetDirection().Equals(Direction.DOWN))
            {
                if (playerY != sizeY - 1)
                {
                    if (entityLayer[playerY + 1, playerX].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerY, playerX] = new EmptyEntity();

                        playerY++;

                        entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.DOWN);
                    }
                }
                else
                {
                    Input();
                }
            }
            else if (keyPressed.Equals(ConsoleKey.DownArrow) && !player.GetDirection().Equals(Direction.DOWN))
            {
                entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.DOWN);
            }

            if (keyPressed.Equals(ConsoleKey.LeftArrow) && player.GetDirection().Equals(Direction.LEFT))
            {
                if (playerX != 0)
                {
                    if (entityLayer[playerY, playerX - 1].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerY, playerX] = new EmptyEntity();

                        playerX--;

                        entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.LEFT);
                    }
                }
                else
                {
                    Input();
                }
            }
            else if (keyPressed.Equals(ConsoleKey.LeftArrow) && !player.GetDirection().Equals(Direction.LEFT))
            {
                entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.LEFT);
            }

            if (keyPressed.Equals(ConsoleKey.RightArrow) && player.GetDirection().Equals(Direction.RIGHT))
            {
                if (playerX != sizeX - 1)
                {
                    if (entityLayer[playerY, playerX + 1].GetType().Name.Equals("EmptyEntity"))
                    {
                        entityLayer[playerY, playerX] = new EmptyEntity();

                        playerX++;

                        entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.RIGHT);
                    }
                }
                else
                {
                    Input();
                }
            }
            else if (keyPressed.Equals(ConsoleKey.RightArrow) && !player.GetDirection().Equals(Direction.RIGHT))
            {
                entityLayer[playerY, playerX] = new Player(playerX, playerY, Direction.RIGHT);
            }

            IsAPressed(keyPressed, player);
            IsTabPressed(keyPressed);
            IsEscapePressed(keyPressed);
        }

        private void IsAPressed(ConsoleKey keyPressed, Player player)
        {
            if (keyPressed.Equals(ConsoleKey.A))
            {
                if (player.GetDirection().Equals(Direction.UP))
                {
                    if (!(playerY - 1 < 0))
                    {
                        CollectItem(itemLayer[playerY - 1, playerX].GetType().Name.ToString());
                        itemLayer[playerY - 1, playerX] = new EmptyItem();
                    }
                }

                if (player.GetDirection().Equals(Direction.DOWN))
                {
                    if (!(playerY > sizeY - 1))
                    {
                        CollectItem(itemLayer[playerY + 1, playerX].GetType().Name.ToString());
                        itemLayer[playerY + 1, playerX] = new EmptyItem();
                    }
                }

                if (player.GetDirection().Equals(Direction.LEFT))
                {
                    if (!(playerX - 1 < 0))
                    {
                        CollectItem(itemLayer[playerY, playerX - 1].GetType().Name.ToString());
                        itemLayer[playerY, playerX - 1] = new EmptyItem();
                    }
                }

                if (player.GetDirection().Equals(Direction.RIGHT))
                {
                    if (!(playerX > sizeX - 1))
                    {
                        CollectItem(itemLayer[playerY, playerX + 1].GetType().Name.ToString());
                        itemLayer[playerY, playerX + 1] = new EmptyItem();
                    }
                }
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

        private void Display(int playerX, int playerY)
        {
            Console.Clear();

            Console.Out.WriteLine();
            Console.Out.Write("  ");
            PlayerInformation.DisplayHealthBar();

            ApplyFormating();
            for (int y = playerY - offsetY; y < playerY + offsetY; y++)
            {
                Console.BackgroundColor = ConsoleColor.Black;

                for (int x = playerX - offsetX; x < playerX + offsetX; x++)
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

            if (!IsSafePlace(x,y))
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
