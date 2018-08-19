using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public interface IItemDisplayable
    {
        /// <summary>
        /// Return if Item is Displayable or not
        /// </summary>
        /// <returns>
        /// true: Displayable
        /// false: Not Displayable
        /// </returns>
        bool TrueOrFalse();

        /// <summary>
        /// If Displayable this method will Display the Item
        /// </summary>
        /// <param name="locationColor">
        /// This is the color used when displaying the Item
        /// </param>
        void Display(ConsoleColor locationColor);

        /// <summary>
        /// If Displayable this method will return the symbol associated with the Item
        /// </summary>
        /// <returns>Nullable char symbol</returns>
        char? GetSymbol();

        /// <summary>
        /// If Displayable this methd will return the color associated with the Item
        /// </summary>
        /// <returns></returns>
        ConsoleColor GetColor();
    }
}
