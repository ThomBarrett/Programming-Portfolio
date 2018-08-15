using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.Misc
{
    class IsLocationDisplayable : ILocationDisplayable
    {
        private char symbol;
        private ConsoleColor backgroundColor;
        private ConsoleColor foregroundColor;

        public IsLocationDisplayable(char symbol, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            this.symbol = symbol;
            this.backgroundColor = backgroundColor;
            this.foregroundColor = foregroundColor;
        }

        public void Display()
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Out.Write(symbol);
        }

        public ConsoleColor GetColor()
        {
            return backgroundColor;
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
