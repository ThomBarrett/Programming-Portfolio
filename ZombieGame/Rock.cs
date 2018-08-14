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
            this.x = x;
            this.y = y;
            this.color = ConsoleColor.Black;
            this.symbol = '*';

            this.ammount = 1;
        }

        public override void AddAmmount(int ammount)
        {
            throw new NotImplementedException();
        }

        public override void Display(ConsoleColor locationColor)
        {
            Console.BackgroundColor = locationColor;
            Console.ForegroundColor = this.color;

            Console.Out.Write(symbol);
        }

        public override int? GetAmmount()
        {
            throw new NotImplementedException();
        }

        public override ConsoleColor GetColor()
        {
            return this.color;
        }

        public override char? GetSymbol()
        {
            return this.symbol;
        }

        public override bool IsConsumable()
        {
            throw new NotImplementedException();
        }

        public override void MinusAmmount(int ammount)
        {
            throw new NotImplementedException();
        }
    }
}