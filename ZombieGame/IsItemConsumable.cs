using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class IsItemConsumable : IItemConsumable
    {
        private int? ammount = null;

        public IsItemConsumable(int ammount)
        {
            this.ammount = ammount;
        }

        public void AddAmmount(int ammount)
        {
            this.ammount += ammount;
        }

        public int? GetAmmount()
        {
            return this.ammount;
        }

        public void MinusAmmount(int ammount)
        {
            if (ammount <= this.ammount)
            {
                this.ammount -= ammount;
            }
        }

        public bool TrueOrFalse()
        {
            return true;
        }
    }
}