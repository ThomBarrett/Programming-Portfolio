using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{

    abstract class Location
    {
        protected string type;
        protected ILocationDisplayable displayable;

        public ILocationDisplayable GetDisplayable()
        {
            return displayable;
        }

        public abstract new string GetType();
    }
}
