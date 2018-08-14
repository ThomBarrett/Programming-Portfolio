using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class EmptyItem : Item
    {
        public override void AddAmmount(int ammount)
        {
            throw new NotImplementedException();
        }

        public override void Display(ConsoleColor locationColor)
        {
            throw new NotImplementedException();
        }

        public override int? GetAmmount()
        {
            throw new NotImplementedException();
        }

        public override ConsoleColor GetColor()
        {
            throw new NotImplementedException();
        }

        public override char? GetSymbol()
        {
            throw new NotImplementedException();
        }

        public override bool IsConsumable()
        {
            throw new NotImplementedException();
        }

        public override void MinusAmmount(int ammount)
        {
            throw new NotImplementedException();
        }
    }
}
