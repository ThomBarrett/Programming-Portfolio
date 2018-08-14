using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public static class PlayerInformation
    {
        private static float MaxHP = 200;
        private static float HP = MaxHP;

        private static float XPRequired = 200;
        private static float XP = 0;


        private static Dictionary<int, Item> inventory = new Dictionary<int, Item>();
        private static Item[] hotbar = {
            new EmptyItem(), new EmptyItem(), new EmptyItem(), new EmptyItem(), new EmptyItem(),
            new EmptyItem(), new EmptyItem(), new EmptyItem(), new EmptyItem(), new EmptyItem()
        };

        private static int hotbarCurrentSlot = 0;

        public static void AddItem(int id, Item item)
        {
            if (inventory.ContainsKey(id))
            {
                inventory[id].AddAmmount((int)item.GetAmmount());
            }
            else
            {
                inventory.Add(id, item);
            }
        }


        public static bool RemoveItem(int id, Item item)
        {
            if (inventory[id].GetAmmount() > item.GetAmmount())
            {
                inventory[id].MinusAmmount((int)item.GetAmmount());
                return true;
            }
            else if (inventory[id].GetAmmount() == item.GetAmmount())
            {
                inventory.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Item SearchItemByID(int id)
        {
            if (inventory.ContainsKey(id))
            {
                return inventory[id];
            }
            else
            {
                return new EmptyItem();
            }
        }

        private static void OrderInventory()
        {
            foreach (var item in inventory.OrderByDescending(key => key.Key))
            {

            }
        }

        public static void DisplayGameMenu()
        {
            Console.Clear();
            Console.Out.WriteLine(" ╔══════╗");
            Console.Out.WriteLine(" ║ Menu ║");
            Console.Out.Write(" ╠");

            for (int i = 0; i < 116; i++)
            {
                if (i == 6)
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

            Console.Out.WriteLine(" ║ (1)Inventory                                         (2)Player                                         (3)Crafting ║");

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

            if (input == "1")
            {
                DisplayInventory();
                return;
            }

            if (input == "2")
            {
                DisplayPlayer();
                return;
            }

            if (input == "3")
            {
                DisplayCrafting();
                return;
            }


        }

        public static void DisplayInventory()
        {
            Console.Out.WriteLine("   < | > INVENTORY < | >");
            Console.Out.WriteLine();
            OrderInventory();
            foreach (KeyValuePair<int, Item> kv in inventory)
            {
                int id = kv.Key;
                string data = kv.Value.GetType().Name + ": " + kv.Value.GetAmmount();

                Console.WriteLine($" │( { id } ) { data } │ ");
            }
            Console.Out.WriteLine();
            Console.Out.Write("Item ID > ");

            try
            {
                int input = int.Parse(Console.In.ReadLine());
                Console.In.Close();
                SoundSystem.PlayEnterSound();

                if (inventory.ContainsKey(input) == true)
                {
                    ItemOptions(input);
                }
                else
                {
                    Console.Out.WriteLine("No Item buy this ID");
                    Console.Read();
                    Console.In.Close();
                    SoundSystem.PlayEnterSound();
                    DisplayInventory();
                }
            }
            catch (FormatException fe)
            {
                Console.In.Close();
            }



        }

        private static void ItemOptions(int id)
        {
            Console.Clear();
            string itemName = inventory[id].GetType().Name;
            Console.Out.WriteLine(" ╔══════╗");
            Console.Out.WriteLine($" ║ { itemName } ║");
            Console.Out.Write(" ╠");

            for (int i = 0; i < 116; i++)
            {
                if (i == itemName.Length + 2)
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

            Console.Out.WriteLine(" ║ (1)Use                                            (2)Equip                                                 (3)Drop ║");

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

            if (input == "1")
            {
                //USE
                return;
            }
            if (input == "2")
            {
                DisplayHotbar();
                Console.Out.WriteLine();


                Console.Out.Write("Select Slot > ");

                string slot = Console.In.ReadLine();
                slot = slot.Trim();
                Console.In.Close();
                SoundSystem.PlayEnterSound();
                Console.Clear();
                var item = inventory[id];
                switch (slot)
                {
                    case "1":
                        PutItemInHotbar(0, ref item);
                        break;
                    case "2":
                        PutItemInHotbar(1, ref item);
                        break;
                    case "3":
                        PutItemInHotbar(2, ref item);
                        break;
                    case "4":
                        PutItemInHotbar(3, ref item);
                        break;
                    case "5":
                        PutItemInHotbar(4, ref item);
                        break;
                    case "6":
                        PutItemInHotbar(5, ref item);
                        break;
                    case "7":
                        PutItemInHotbar(6, ref item);
                        break;
                    case "8":
                        PutItemInHotbar(7, ref item);
                        break;
                    case "9":
                        PutItemInHotbar(8, ref item);
                        break;
                    case "0":
                        PutItemInHotbar(9, ref item);
                        break;

                    default:
                        ItemOptions(id);
                        break;
                }
                return;
            }
            if (input == "3")
            {
                return;
            }
        }

        public static void DisplayHotbar()
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine(" ╔═╗ ╔═╗ ╔═╗ ╔═╗ ╔═╗ ╔═╗ ╔═╗ ╔═╗ ╔═╗ ╔═╗");
            Console.Out.WriteLine(" ║1║ ║2║ ║3║ ║4║ ║5║ ║6║ ║7║ ║8║ ║9║ ║0║");

            for (int i = 0; i < 10; i++)
            {
                char space;
                if (hotbar[i].GetType().Name.Equals("EmptyItem"))
                {
                    space = ' ';
                }
                else
                {
                    space = '*';
                }
                Console.Out.Write($" ║{ space }║");
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine(" ╚═╝ ╚═╝ ╚═╝ ╚═╝ ╚═╝ ╚═╝ ╚═╝ ╚═╝ ╚═╝ ╚═╝");

            switch (hotbarCurrentSlot)
            {
                case 0:
                    Console.Out.WriteLine("  ^");
                    break;

                case 1:
                    Console.Out.WriteLine("      ^");
                    break;

                case 2:
                    Console.Out.WriteLine("          ^");
                    break;

                case 3:
                    Console.Out.WriteLine("              ^");
                    break;

                case 4:
                    Console.Out.WriteLine("                  ^");
                    break;

                case 5:
                    Console.Out.WriteLine("                      ^");
                    break;

                case 6:
                    Console.Out.WriteLine("                          ^");
                    break;

                case 7:
                    Console.Out.WriteLine("                              ^");
                    break;

                case 8:
                    Console.Out.WriteLine("                                  ^");
                    break;

                case 9:
                    Console.Out.WriteLine("                                      ^");
                    break;
            }
            if(hotbar[hotbarCurrentSlot].GetType().Name != "EmptyItem")
            {
                Console.Out.WriteLine($"{ hotbar[hotbarCurrentSlot].GetType().Name }: { hotbar[hotbarCurrentSlot].GetAmmount() }");
            }
        }

        private static void PutItemInHotbar(int slot, ref Item item)
        {
            hotbar[slot] = item;
        }

        public static void DisplayPlayer()
        {
            Console.Out.WriteLine("   < | > PLAYER < | >");
            Console.Out.WriteLine();

            DisplayAllBars();

            Console.Read();

        }

        public static void DisplayAllBars()
        {
            DisplayHealthBar();
            Console.Out.WriteLine();
            DisplayXPBar();
        }

        public static void DisplayHealthBar()
        {
            float percentHP = HP / MaxHP * 100;
            Console.Out.Write("  HP: [");
            if (percentHP > 79)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (percentHP < 79 && percentHP > 25)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            for (int i = 0; i < percentHP; i++)
            {
                Console.Out.Write("|");
            }

            float whiteSpace = 100 - percentHP;

            for (int i = 0; i < whiteSpace; i++)
            {
                Console.Out.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine($"] { HP } / { MaxHP }");
        }

        public static void DisplayXPBar()
        {
            float percentXP = XP / XPRequired * 100;
            Console.Out.Write("  XP: [");

            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < percentXP; i++)
            {
                Console.Out.Write("|");
            }

            float whiteSpace = 100 - percentXP;

            for (int i = 0; i < whiteSpace; i++)
            {
                Console.Out.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine($"] { XP } / { XPRequired }");
        }

        public static void HotbarSlotSet(int slot)
        {
            hotbarCurrentSlot = slot;
        }

        public static void DisplayCrafting()
        {
            Console.Out.WriteLine("   < | > CRAFTING < | >");
            Console.Out.WriteLine();

            RecipesSingleton recipes = RecipesSingleton.Instance;
            recipes.DisplayRecipes();
        }

    }


}
