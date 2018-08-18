using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    /// <summary>
    /// EmptyItem is used if a empty Item space is required.
    /// /// Inherits from Item. <see cref="ZombieGame.Item"/>
    /// </summary>
    class EmptyItem : Item
    {
        /// <summary>
        /// Creates the EmptyItem.
        /// EmptyItem is not Displayable. <see cref="ZombieGame.IItemDisplayable"/>
        /// EmptyItem is not Consumable. <see cref="ZombieGame.IItemConsumable"/>
        /// </summary>
        public EmptyItem()
        {
            this.displayable = new NotItemDisplayable();
            this.consumable = new NotItemConsumable();
        }


    }
}
