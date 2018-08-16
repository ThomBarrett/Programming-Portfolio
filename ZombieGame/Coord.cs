using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Coord
    {
        public uint x { get; set; }
        public uint y { get; set; }

        public Coord(int x, int y)
        {
            this.x = (uint)x;
            this.y = (uint)y;
        }

        public Coord(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
