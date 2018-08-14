using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    abstract class Recipe
    {
        protected Item[] requiredItems = null;
        protected int productID;
        public string name { get; set; }
        protected bool unlocked = true;

        public abstract void AttemptCrafting();

        protected abstract Item Craft();
    }
}
