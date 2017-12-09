using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class UnBreaking : Breakable
    {
        private bool breaking = false; 
        public bool Break()
        {
            return false;
        }

        public bool GetBreakable()
        {
            return breaking;
        }
    }
}
