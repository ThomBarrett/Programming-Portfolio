using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Misc;

namespace ZombieGame
{
    class Water : Location
    {
        public Water() {
            this.type = "Water";
            this.displayable = new IsLocationDisplayable('▒', ConsoleColor.Blue, ConsoleColor.Cyan);
        }

        public override string GetType()
        {
            return this.type;
        }
    }
}
