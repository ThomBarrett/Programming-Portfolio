using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{

    class Home : Place
    {
        private Town town;
        public void Visit(Player player, Town town)
        {
            this.town = town;
            Console.Clear();
            GameUtils.AnimateLine("Welcome Home!");
            DisplayHomeOptions();
            Leave();
        }
        public void Leave()
        {
            Console.Clear();
            GameUtils.AnimateAwait("You into the Town...");
            town.WhereDoYouWantToVisit();
        }

        private void DisplayHomeOptions()
        {
            Console.Out.Write("(0) "); GameUtils.AnimateLine("Sleep");
            Console.Out.Write("(1) "); GameUtils.AnimateLine("Meal");

            ChooseHomeOptions(Console.In.ReadLine());
        }

        private void ChooseHomeOptions(string input)
        {
            switch (input)
            {
                case "0":
                    GameUtils.AnimateLine("Sleep");
                    // Save the game into a txt file
                    break;
                case "1":
                    GameUtils.AnimateLine("Meal");
                    // Allow player to make food and gain new stats
                    break;

                default:
                    DisplayHomeOptions();
                    break;
            }
        }

        public void PassTheTown(Town town)
        {
            this.town = town;
        }
    }
}
