using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    interface Place
    {
        void Visit(Player player,Town town);
        void Leave();

        void PassTheTown(Town town);
    }
}
