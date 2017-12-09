using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class Town
    {
        private Player player;

        private Home home;
        private Dungeons dungeons;
        private Town town;
        public Town(Player player)
        {
            this.player = player;

            home = new Home();
            dungeons = new Dungeons();

            
        }

        public void PassMyInstance(Town town)
        {
            this.town = town;
            home.PassTheTown(town);
            dungeons.PassTheTown(town);
        }
        public void WhereDoYouWantToVisit()
        {
            GameUtils.AnimateLine("Where do you want to vist?");
            Console.Out.Write("(0) "); GameUtils.AnimateLine("Home");
            Console.Out.Write("(1) "); GameUtils.AnimateLine("Dungeons");
            Console.Out.Write("(2) "); GameUtils.AnimateLine("Armoury Shop");
            Console.Out.Write("(3) "); GameUtils.AnimateLine("Magic Shop");
            Console.Out.Write("(4) "); GameUtils.AnimateLine("Furniture Shop");
            Console.Out.Write("(5) "); GameUtils.AnimateLine("Town Square");

            switch (Console.In.ReadLine())
            {
                case "0":
                    Console.Clear();
                    home.Visit(player,town);
                    break;
                case "1":
                    Console.Clear();
                    dungeons.Visit(player,town);
                    break;
                default:
                    WhereDoYouWantToVisit();
                    break;
            }
        }
    }
}
