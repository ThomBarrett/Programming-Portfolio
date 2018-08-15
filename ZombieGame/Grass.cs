﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Misc;

namespace ZombieGame
{
    class Grass : Location
    {
        public Grass() {
            this.type = "Grass";
            this.displayable = new IsLocationDisplayable('░', ConsoleColor.Green, ConsoleColor.DarkGreen);
        }

        public override string GetType()
        {
            return this.type;
        }
    }
}
