using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Stone : Item
    { 
        public Stone(int total)
        {
            this.displayable = new NotItemDisplayable();
            this.consumable = new IsItemConsumable(total);
        }
    }
}