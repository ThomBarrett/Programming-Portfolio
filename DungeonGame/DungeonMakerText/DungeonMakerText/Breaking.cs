using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class Breaking : Breakable
    {
        bool breaking = true;
        public bool Break()
        {
            return true;
        }

        public bool GetBreakable()
        {
            return breaking;
        }
    }
}
