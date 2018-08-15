using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public interface ILocationDisplayable
    {
        bool TrueOrFalse();
        void Display();
        char? GetSymbol();
        ConsoleColor GetColor();
    }
}
