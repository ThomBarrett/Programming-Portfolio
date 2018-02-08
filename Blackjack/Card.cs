using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        // '♠'♥''♣''♦'
        private char type;
        
        private String name;
        private int? value = null;
        private int? aceValue = null;
        public Card(char type, String name)
        {
            switch (type)
            {
                case 'H':
                    this.type = '♥';
                    break;
                case 'S':
                    this.type = '♠';
                    break;
                case 'C':
                    this.type = '♣';
                    break;
                case 'D':
                    this.type = '♦';
                    break;
                default:
                    throw new IllegalStateException("Invalid Suit!");
            }
            this.name = name;

            switch (name)
            {
                case "A":
                    this.value = 11; this.aceValue = 1;
                    break;

                case "K":
                    this.value = 10;
                    break;

                case "Q":
                    this.value = 10;
                    break;

                case "J":
                    this.value = 10;
                    break;

                case "10":
                    this.value = 10;
                    break;

                case "9":
                    this.value = 9;
                    break;

                case "8":
                    this.value = 8;
                    break;

                case "7":
                    this.value = 7;
                    break;

                case "6":
                    this.value = 6;
                    break;

                case "5":
                    this.value = 5;
                    break;

                case "4":
                    this.value = 4;
                    break;

                case "3":
                    this.value = 3;
                    break;

                case "2":
                    this.value = 2;
                    break;

                default:
                    throw new IllegalStateException("Invalid Name!");
            }
        }

        public void Print()
        {
            if(type == '♥' || type == '♦')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.OutputEncoding = Encoding.UTF8;
            Console.Out.Write("  " + name + type + " ");
        }

        public int? getMaxValue()
        {
            return value;
        }

        public int? getAceValue()
        {
            return aceValue;
        }
    }
}
