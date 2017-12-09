using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    static class GameUtils
    {        
        //  Text Animation Functions  \\
        public static void AnimateLine(string text)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(31);
            }
            Console.Out.WriteLine();
        }
        public static void AnimateLine(string text, int delay)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.Out.WriteLine();
        }
        public static void AnimateAwait(string text)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(31);
            }
            Console.Out.WriteLine();
            while (true)
            {
                ConsoleKeyInfo awaitedinput = Console.ReadKey(true);
                if (awaitedinput.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public static void AnimateAwait(string text, int delay)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.Out.WriteLine();
            while (true)
            {
                ConsoleKeyInfo awaitedinput = Console.ReadKey(true);
                if (awaitedinput.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public static void AnimateAwait(string text, char key)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(31);
            }
            Console.Out.WriteLine();
            while (true)
            {
                ConsoleKeyInfo awaitedinput = Console.ReadKey(true);
                if (awaitedinput.KeyChar == key)
                {
                    break;
                }
            }
        }
        public static void AnimateAwait(string text, char key, int delay)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.Out.WriteLine();
            while (true)
            {
                ConsoleKeyInfo awaitedinput = Console.ReadKey(true);
                if (awaitedinput.KeyChar == key)
                {
                    break;
                }
            }
        }
        public static void Animate(string text)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(31);
            }
        }
        public static void Animate(string text, int delay)
        {
            char[] texttoanimate = text.ToCharArray();

            foreach (char c in texttoanimate)
            {
                Console.Out.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            /**
             * HP 30
             * MP 8
             * ATK 8
             * DEF 5
             * STR 3
             * SPD 4
             * CON 3
             * WIS 5
             **/
            Player player = new Player(); 
            Console.ForegroundColor = ConsoleColor.Green;
            Town town = new Town(player);
            town.PassMyInstance(town);

            town.WhereDoYouWantToVisit();
            GameUtils.AnimateAwait("");
        }
    }
}
