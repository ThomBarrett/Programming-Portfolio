using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{

    abstract class Location
    {
        protected string type;
        protected char symbol;
        public abstract char GetSymbol();

        protected ConsoleColor color;
        public abstract ConsoleColor GetColor();

        public abstract void Display();

        public abstract new string GetType();
    }
}
