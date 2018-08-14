using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    /*
        Title class creates the Title using Display Method
        Then Uses input function to take the input
    */
    class Title
    {
        private string title = "2D days to die";

        //Display Functions
        public void Display()
        {
            DrawAll();
        }

        private void DrawAll()
        {
            DrawBox();
            DrawOptions();
        }

        private void DrawBox()
        {
            DrawBoxTop();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxText();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxCenter();
            DrawBoxBottom();
        }

        private void DrawBoxTop()
        {
            Console.Out.Write(" ╔");
            for (int i = 0; i < 118; i++)
            {
                Console.Write('═');
            }
            Console.Out.WriteLine('╗');
        }

        private void DrawBoxCenter()
        {
            Console.Out.Write(" ║");

            for (int i = 0; i < 118; i++)
            {
                Console.Write(' ');
            }

            Console.Out.WriteLine("║");
        }

        private void DrawBoxText()
        {
            Console.Out.Write(" ║");

            for (int i = 0; i < 59 - title.Length / 2; i++)
            {
                Console.Write(' ');
            }
            Console.Out.Write(title);

            for (int i = 0; i < 52; i++)
            {
                Console.Write(' ');
            }

            Console.Out.WriteLine("║");
        }

        private void DrawBoxBottom()
        {
            Console.Out.Write(" ╚");
            for (int i = 0; i < 118; i++)
            {
                Console.Write('═');
            }
            Console.Out.WriteLine('╝');
        }

        private void DrawOptions()
        {
            Console.Out.WriteLine();

            for (int i = 0; i < 59 - 2; i++)
            {
                Console.Write(' ');
            }
            Console.Out.WriteLine("New Game (0)");

            for (int i = 0; i < 59 - 4; i++)
            {
                Console.Write(' ');
            }
            Console.Out.WriteLine("────────────────");

            for (int i = 0; i < 59 - 2; i++)
            {
                Console.Write(' ');
            }
            Console.Out.WriteLine("Continue (1)");

        }
        //Display Functions

        //Input Function
        public bool Input()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.In.Close();

            if(keyInfo.Key == ConsoleKey.D0)
            {
                return false;
            }
            else if(keyInfo.Key == ConsoleKey.D1)
            {
                return true;
            }
            else
            {
                return Input();
            }

            
        }
        //Input Function
    }
}
