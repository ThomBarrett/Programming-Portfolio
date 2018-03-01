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
            switch (type) //Based on type assign the correct symbol
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

            switch (name) // Assign the correct values to each card
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
            if(type == '♥' || type == '♦') //Based on suit it will the font colour will change
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.OutputEncoding = Encoding.UTF8; //Change the encoding of the output to allow the card symbols to be displayed. Make sure the CMD font is compatatable or you will get boxes with question marks
            Console.Out.Write("  " + name + type + " ");
        }

        public int? getMaxValue()
        {
            return value;
        }

        public int? getAceValue() //This function exists for the ace card because a ACE card can be different values 11 or 1
        {
            return aceValue;
        }
    }
}
