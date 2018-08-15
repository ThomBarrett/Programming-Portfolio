using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class NotItemDisplayable : IItemDisplayable
    {
        public void Display(ConsoleColor locationColor)
        {
            throw new NotImplementedException();
        }

        public ConsoleColor GetColor()
        {
            throw new NotImplementedException();
        }

        public char? GetSymbol()
        {
            throw new NotImplementedException();
        }

        public bool TrueOrFalse()
        {
            return false;
        }
    }
}
