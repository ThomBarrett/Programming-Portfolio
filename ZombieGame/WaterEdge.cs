using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Misc;

namespace ZombieGame
{
    class WaterEdge : Location
    {
        public WaterEdge() {
            this.type = "WaterEdge";
            this.displayable = new IsLocationDisplayable('▒', ConsoleColor.Cyan, ConsoleColor.Blue);
        }

        public override string GetType()
        {
            return this.type;
        }
    }
}
