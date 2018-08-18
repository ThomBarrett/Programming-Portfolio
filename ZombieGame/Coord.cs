using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    /// <summary>
    /// Coord is used to keep track of X and Y positions.
    /// </summary>
    sealed class Coord
    {
        /// <summary>
        /// Represents the X position of the Coordinate
        /// </summary>
        public uint x { get; set; }

        /// <summary>
        /// Represents the Y position of the Coordinate.
        /// </summary>
        public uint y { get; set; }

        /// <summary>
        /// Creates Coord object by taking two int param that will get converted to uint.
        /// </summary>
        /// <param name="x">
        /// Represents the "X" position of this Coordinate.
        /// </param>
        /// <param name="y">
        /// Represents the "Y" position of this Coordinate.
        /// </param>
        public Coord(int x, int y)
        {
            this.x = (uint)x;
            this.y = (uint)y;
        }

        /// <summary>
        /// Creates Coord object by taking two uint param.
        /// </summary>
        /// <param name="x">
        /// Represents the "X" position of this Coordinate.
        /// </param>
        /// <param name="y">
        /// Represents the "Y" position of this Coordinate.
        /// </param>
        public Coord(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
