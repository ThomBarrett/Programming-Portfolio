using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class StoneAxeRecipe : Recipe
    {
        public StoneAxeRecipe()
        {
            requiredItems = new Item[] { new Wood(2), new Stone(4) };
            name = "Stone Axe";
            productID = 20;
        }


        public override void AttemptCrafting()
        {
            Item item = Craft();

            if (item.GetType().Name != "EmptyItem")
            {
                PlayerInformation.AddItem(productID, item);
                Console.Out.WriteLine("AXESSS");
            }
        }

        protected override Item Craft()
        {
            bool craftable = true;
            Item wood = PlayerInformation.SearchItemByID(0);
            Item stone = PlayerInformation.SearchItemByID(1);

            if (wood.GetType().Name != "EmptyItem" && stone.GetType().Name != "EmptyItem")
            {
                if (!(requiredItems[0].GetAmmount() <= wood.GetAmmount()))
                {
                    craftable = false;
                }

                if (!(requiredItems[1].GetAmmount() <= stone.GetAmmount()))
                {
                    craftable = false;
                }

                if(craftable == true)
                {
                    return new StoneAxe();
                }
                else
                {
                    return new EmptyItem();
                }
            }
            else
            {
                return new EmptyItem();
            }


        }
    }
}
