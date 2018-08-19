using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Misc;

namespace ZombieGame
{
    class Grass : Location
    {
        /// <summary>
        /// Create Grass type Location.
        /// Inherits from: <see cref="Location"/>
        /// </summary>
        public Grass() {
            this.type = "Grass";
            this.displayable = new IsLocationDisplayable('░', ConsoleColor.Green, ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Return type information associated with Grass
        /// </summary>
        /// <returns></returns>
        public override string GetType()
        {
            return this.type;
        }
    }
}
