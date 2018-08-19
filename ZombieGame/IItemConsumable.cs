using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public interface IItemConsumable
    {
        /// <summary>
        /// Return if Item is Consumable or not
        /// </summary>
        /// <returns>
        /// true: Consumable
        /// false: Not Consumable
        /// </returns>
        bool TrueOrFalse();

        /// <summary>
        /// If consumable this method gives the amount of the Item Associated to 
        /// </summary>
        /// <returns>Nullable int amount</returns>
        int? GetAmmount();

        /// <summary>
        /// Allows for adding to the Items amount
        /// </summary>
        /// <param name="ammount">Amount to add to the item amount</param>
        void AddAmmount(int ammount);

        /// <summary>
        /// Allows for minusing the Items amount
        /// </summary>
        /// <param name="ammount">Amount to take away from the item amount</param>
        void MinusAmmount(int ammount);
    }
}
