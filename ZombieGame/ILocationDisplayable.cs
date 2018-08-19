using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public interface ILocationDisplayable
    {
        /// <summary>
        /// Return if Location is Displayable or not
        /// </summary>
        /// <returns>
        /// true: Displayable
        /// false: Not Displayable
        /// </returns>
        bool TrueOrFalse();

        /// <summary>
        /// If Location is Displayable then this method will display it
        /// </summary>
        void Display();

        /// <summary>
        /// If Location is Displayble then this method will return the associated symbol
        /// </summary>
        /// <returns>Nullable char symbol</returns>
        char? GetSymbol();

        /// <summary>
        /// If Location is Displayable then this method will return the associated color
        /// </summary>
        /// <returns>Associated color</returns>
        ConsoleColor GetColor();
    }
}
