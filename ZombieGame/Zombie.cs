using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Zombie : Entity
    {
        private char symbol = 'Z';
        private ConsoleColor foregroundColor = ConsoleColor.Red;

        public override void Display(ConsoleColor locationColor)
        {
            Console.BackgroundColor = locationColor;
            Console.ForegroundColor = foregroundColor;

            Console.Out.Write(symbol);
        }

        public override ConsoleColor GetColor()
        {
            throw new NotImplementedException();
        }

        public override char GetSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
