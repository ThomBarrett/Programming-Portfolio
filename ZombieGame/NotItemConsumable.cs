using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class NotItemConsumable : IItemConsumable
    {

        public void AddAmmount(int ammount)
        {
            throw new NotImplementedException();
        }

        public int? GetAmmount()
        {
            throw new NotImplementedException();
        }

        public void MinusAmmount(int ammount)
        {
            throw new NotImplementedException();
        }

        public bool TrueOrFalse()
        {
            return false;
        }
    }
}
