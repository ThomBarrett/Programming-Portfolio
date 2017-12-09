using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class CannotSpawn : Spawnable
    {
        public bool TryToSpawn()
        {
            return false;
        }
    }
}
