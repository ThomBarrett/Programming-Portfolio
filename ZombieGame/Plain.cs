using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Plain : Location
    {
        public Plain() {
            this.type = "Plain";
            this.symbol = ' ';
            this.color = ConsoleColor.DarkYellow;
        }

        public override char GetSymbol()
        {
            return this.symbol;
        }
    
        public override ConsoleColor GetColor()
        {
            return this.color;
        }

        public override void Display()
        {
            Console.BackgroundColor = color;
            Console.Out.Write(symbol);
        }

        public override string GetType()
        {
            return this.type;
        }
    }
}
