using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMakerText
{
    class Player
    {
        public static int row;
        public static int col;
        public static char orientation = '▸';

        public static string playerName;

        private int MaxHP;
        private int HP;
        private int MaxMP;
        private int MP;
        private int MaxSMP;
        private int SMP;
        private int ATK;
        private int DEF;
        private int STR;
        private int SPD;
        private int CON;
        private int WIS;

        public Player()
        {
            this.MaxHP = 30;
            this.MaxMP = 8;
            this.HP = MaxHP;
            this.MP = MaxMP;

            this.MaxSMP = 10;
            this.SMP = MaxSMP;

            this.ATK = 8;
            this.DEF = 5;
            this.STR = 3;
            this.SPD = 4;
            this.CON = 3;
            this.WIS = 5;


            CreateName();
        }

        private void CreateName() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            GameUtils.AnimateLine("What's Your Name?");

            Console.ForegroundColor = ConsoleColor.White;
            string tempName = Console.In.ReadLine();

            ValidateName(tempName);


        }

        private void ValidateName(string input)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            GameUtils.AnimateLine("Is " + input + " correct? Y/N");

            Console.ForegroundColor = ConsoleColor.White;
            string YesOrNo = Console.In.ReadLine();

            switch (YesOrNo)
            {
                case "Y":
                    Console.Clear();
                    playerName = input;
                    break;
                case "y":
                    Console.Clear();
                    playerName = input;
                    break;
                case "YES":
                    Console.Clear();
                    playerName = input;
                    break;
                case "Yes":
                    Console.Clear();
                    playerName = input;
                    break;
                case "yes":
                    Console.Clear();
                    playerName = input;
                    break;

                case "N":
                    Console.Clear();
                    CreateName();
                    break;
                case "n":
                    Console.Clear();
                    CreateName();
                    break;
                case "NO":
                    Console.Clear();
                    CreateName();
                    break;
                case "No":
                    Console.Clear();
                    CreateName();
                    break;
                case "no":
                    Console.Clear();
                    CreateName();
                    break;

                default:
                    ValidateName(input);
                    break;
            }
        }

        public string GetName() {
            return playerName;
        }

        public int GetStat(string input){
            switch (input) {

                case "MaxHP":
                    return this.MaxHP;
                case "HP":
                    return this.HP;

       
                case "MaxMP":
                    return this.MaxMP;
                case "MP":
                    return this.MP;

                case "MaxSMP":
                    return this.MaxSMP;

                case "SMP":
                    return this.SMP;

                case "ATK":
                    return this.ATK;
                case "DEF":
                    return this.DEF;
                case "STR":
                    return this.STR;
                case "SPD":
                    return this.SPD;
                case "CON":
                    return this.CON;
                case "WIS":
                    return this.WIS;

                default:
                    return 0130;

            }
        }

        public void SMPuse()
        {
            this.SMP--;
        }

        public void HPToMax() {
            this.HP = MaxHP;
        }

        public void MPToMax()
        {
            this.MP = MaxMP;
        }
        public void SMPToMax()
        {
            this.SMP = MaxSMP;
        }
    }
}
