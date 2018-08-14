using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class EmptyEntity : Entity
    {
        public override void Display(ConsoleColor locationColor)
        {
            throw new NotImplementedException();
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
