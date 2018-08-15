using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Wood : Item
    {

        public Wood(int total)
        {
            this.displayable = new NotItemDisplayable();
            this.consumable = new IsItemConsumable(total);
        }
    }
}