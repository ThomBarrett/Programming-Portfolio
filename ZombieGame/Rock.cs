using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Rock : Item
    {
        public Rock(int x, int y)
        {
            this.displayable = new IsItemDisplayable(x, y, '*', ConsoleColor.Black);
            this.consumable = new NotItemConsumable();
        }
    }
}