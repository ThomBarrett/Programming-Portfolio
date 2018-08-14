using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Wood : Item
    {
        public Wood()
        {
            this.ammount = 1;
        }

        public Wood(int total)
        {
            this.ammount = total;
        }

        public override void Display(ConsoleColor locationColor)
        {

        }

        public override ConsoleColor GetColor()
        {
            return this.color;
        }

        public override char? GetSymbol()
        {
            return this.symbol;
        }

        public override int? GetAmmount()
        {
            return this.ammount;
        }

        public override void AddAmmount(int ammount)
        {
            this.ammount += ammount;
        }

        public override void MinusAmmount(int ammount)
        {
            if (ammount <= this.ammount)
            {
                this.ammount -= ammount;
            }
        }

        public override bool IsConsumable()
        {
            return true;
        }
    }
}