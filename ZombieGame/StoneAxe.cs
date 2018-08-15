using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class StoneAxe : Item
    {
        public StoneAxe()
        {
            this.displayable = new NotItemDisplayable();
            this.consumable = new NotItemConsumable();
        }
    }
}
