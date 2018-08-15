using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public interface IItemDisplayable
    {
        bool TrueOrFalse();
        void Display(ConsoleColor locationColor);
        char? GetSymbol();
        ConsoleColor GetColor();
    }
}
