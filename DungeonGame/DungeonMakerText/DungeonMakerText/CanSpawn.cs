using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class CanSpawn : Spawnable
    {
        public bool TryToSpawn()
        {
            Random rand = new Random();
            if (rand.Next(1, 101) <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
