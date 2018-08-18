using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    abstract class Entity
    {
        /// <summary>
        /// Represents the position on the X and Y Axies.
        /// <see cref="ZombieGame.Coord"/>
        /// </summary>
        public Coord position { get; set; }

        /// <summary>
        /// Represents the character that should be displayed with the Display Method.
        /// </summary>
        protected char symbol;

        /// <summary>
        /// Gets the display symbol associated with Entity.
        /// </summary>
        /// <returns>char symbol</returns>
        public abstract char GetSymbol();

        /// <summary>
        /// Represents the symbol color when it is Displayed.
        /// </summary>
        protected ConsoleColor color;

        /// <summary>
        /// Gets the symbol color associated with Entity.
        /// </summary>
        /// <returns>ConsoleColor</returns>
        public abstract ConsoleColor GetColor();

        /// <summary>
        /// Displays symbol in the color associated with Entity and a selcted background color
        /// </summary>
        /// <param name="locationColor">
        /// Used as the background color.
        /// </param>
        public abstract void Display(ConsoleColor locationColor);
    }
}
