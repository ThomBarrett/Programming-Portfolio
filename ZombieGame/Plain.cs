using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Misc;

namespace ZombieGame
{
    class Plain : Location
    {
        public Plain() {
            this.type = "Plain";
            this.displayable = new IsLocationDisplayable('░', ConsoleColor.DarkYellow, ConsoleColor.Black);
        }

        public override string GetType()
        {
            return this.type;
        }
    }
}
