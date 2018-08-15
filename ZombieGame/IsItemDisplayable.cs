using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class IsItemDisplayable : IItemDisplayable
    {
        private int x;
        private int y;

        private char symbol;
        private ConsoleColor color;

        public IsItemDisplayable(int x, int y, char symbol, ConsoleColor color)
        {
            this.x = x;
            this.y = y;

            this.symbol = symbol;

            this.color = color;
        }

        public void Display(ConsoleColor locationColor)
        {
            Console.BackgroundColor = locationColor;
            Console.ForegroundColor = this.color;
            Console.Out.Write(symbol);
        }

        public ConsoleColor GetColor()
        {
            return color;
        }

        public char? GetSymbol()
        {
            return symbol;
        }

        public bool TrueOrFalse()
        {
            return true;
        }
    }
}
