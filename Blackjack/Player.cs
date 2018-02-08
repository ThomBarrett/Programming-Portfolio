using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        private String playerName;
        private LinkedList<Card> playerHand;
        private int? playerScore = 0;
        public Player()
        {
            Console.Out.Write("  Player Name: ");
            SetPlayerName(Console.In.ReadLine());
        }

        public String GetName() 

            => playerName;


        public void SetPlayerName(String playerName) 

            => this.playerName = playerName;


        public int? GetScore()
            
            => playerScore;


        public void GetDeal(ref Queue<Card> dealersCards, ref Queue<Player> players)
        {
            playerHand = new LinkedList<Card>();
            playerHand.AddFirst(dealersCards.Dequeue());
            playerHand.AddFirst(dealersCards.Dequeue());
        }

        public bool Turn(ref Queue<Card> dealersCards, ref Queue<Player> players)
        {
            foreach (Card card in playerHand)
            {
                card.Print();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            int? ammount = 0;
            foreach (Card card in playerHand)
            {
                ammount += card.getMaxValue();
                if (ammount > 21 && card.getAceValue() == 1)
                {
                    ammount -= card.getMaxValue();
                    ammount += card.getAceValue();
                }else if(ammount > 21)
                {
                    Console.Out.WriteLine("Bust!");
                    playerScore = 0;
                    CardsBackToDealer(ref dealersCards);
                    Console.In.ReadLine();
                    return true;
                    //Turn over!
                }else if (ammount == 21)
                {
                    Console.Out.WriteLine("Blackjack!");
                    playerScore = ammount;
                    CardsBackToDealer(ref dealersCards);
                    Console.In.ReadLine();
                    return true;
                }
            }

            Console.Out.WriteLine(ammount);
            Console.Out.WriteLine();

            Console.Out.WriteLine("  ╔═══════════════════════════════╗");
            Console.Out.WriteLine("  ║(1) Hit Me (1)░░░░░░░░░░░░░░░░░║");
            Console.Out.WriteLine("  ║░░░░(2) Stand (2)░░░░░░░░░░░░░░║");
            Console.Out.WriteLine("  ║░░░░░░░░(3) Split (3)░░░░░░░░░░║");
            Console.Out.WriteLine("  ║░░░░░░░░░░░░(4) Double Down (4)║");
            Console.Out.WriteLine("  ╚═══════════════════════════════╝");
            Console.Out.WriteLine();


            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    HitMe(ref dealersCards);
                    Console.Clear();
                    Console.Out.WriteLine(this.playerName);
                    return false;

                case 2:
                    Stand(ref dealersCards, ammount);
                    Console.Clear();
                    Console.Out.WriteLine(this.playerName);
                    return true;

                case 3:
                    Split();
                    break;

                case 4:
                    DoubleDown();
                    break;
            }
            //Hit ME
            //Stand
            //Split
            //Double down
            return false;

        }

        public void HitMe(ref Queue<Card> dealersCards)
        {
            playerHand.AddLast(dealersCards.Dequeue());
        }

        public void Stand(ref Queue<Card> dealersCards, int? ammount)
        {
            playerScore = ammount;
            CardsBackToDealer(ref dealersCards);
        }

        public void Split()
        {
            
        }

        public void DoubleDown()
        {
            
        }

        public void CardsBackToDealer(ref Queue<Card> dealerscards)
        {
            foreach(Card card in playerHand)
            {
                dealerscards.Enqueue(card);
            }
            playerHand.Clear();
        }
        
    }
}
