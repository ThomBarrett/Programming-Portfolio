﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public abstract class Item
    {
        protected int x, y;
        protected ConsoleColor color;
        protected char? symbol = null;
        protected int? ammount = null;

        public abstract char? GetSymbol();
        public abstract ConsoleColor GetColor();
        public abstract int? GetAmmount();
        public abstract void AddAmmount(int ammount);
        public abstract void MinusAmmount(int ammount);
        public abstract void Display(ConsoleColor locationColor);

        public abstract bool IsConsumable();
    }
}