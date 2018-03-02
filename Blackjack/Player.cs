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
            //Create a new linked list and take two cards from the dealersCardsQueue
            playerHand = new LinkedList<Card>();
            playerHand.AddFirst(dealersCards.Dequeue());
            playerHand.AddFirst(dealersCards.Dequeue());
        }

        public bool Turn(ref Queue<Card> dealersCards, ref Queue<Player> players)
        {
            foreach (Card card in playerHand) //Iterate over each card in hand displaying the details to the player
            {
                card.Print();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            int? ammount = 0;
            foreach (Card card in playerHand) //Calculate the total of the cards in players hand. 21 is blackjack over is a bust
            {
                ammount += card.getMaxValue();
                if (ammount > 21 && card.getAceValue() == 1) //Condition for continuation of turn
                {
                    ammount -= card.getMaxValue();
                    ammount += card.getAceValue();
                }else if(ammount > 21) // Condition For BUST
                {
                    Console.Out.WriteLine("Bust!");
                    playerScore = 0;
                    CardsBackToDealer(ref dealersCards);
                    Console.In.ReadLine();
                    return true;
                    //Turn over!
                }else if (ammount == 21)
                {
                    Console.Out.WriteLine("Blackjack!"); Condition For BlackJack
                    playerScore = ammount;
                    CardsBackToDealer(ref dealersCards);
                    Console.In.ReadLine();
                    return true;
                }
            }

            Console.Out.WriteLine(ammount);
            Console.Out.WriteLine();

            Console.Out.WriteLine("  ╔═══════════════════════════════╗"); // Tell the user what options they can perform on their turn
            Console.Out.WriteLine("  ║(1) Hit Me (1)░░░░░░░░░░░░░░░░░║");
            Console.Out.WriteLine("  ║░░░░(2) Stand (2)░░░░░░░░░░░░░░║");
            Console.Out.WriteLine("  ║░░░░░░░░(3) Split (3)░░░░░░░░░░║");
            Console.Out.WriteLine("  ║░░░░░░░░░░░░(4) Double Down (4)║");
            Console.Out.WriteLine("  ╚═══════════════════════════════╝");
            Console.Out.WriteLine();


            switch (int.Parse(Console.ReadLine())) //Let the user select a option and 
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
                    return true; //Turn ends when user Stands

                case 3:
                    Split();
                    break;

                case 4:
                    DoubleDown(ref dealersCards);
                    Console.Clear();
                    Console.Out.WriteLine(this.playerName);
                    return true;
            }
            //Hit ME
            //Stand
            //Split
            //Double down
            return false;

        }

        public void HitMe(ref Queue<Card> dealersCards) //Add another card to hand from dealer
        {
            playerHand.AddLast(dealersCards.Dequeue());
        }

        public void Stand(ref Queue<Card> dealersCards, int? ammount)
        {
            playerScore = ammount; //Score it calculated and stored for the end of the round
            CardsBackToDealer(ref dealersCards); //End of turn to cards back function is called
        }

        public void Split() //Unimplemented
        {
            /*
            According to blackjack rules
            if you have a double on your first two cards you can split them into two seperate hands
            This is called spliting
            */
        }

        public void DoubleDown()
        {
            /*
            According to blackjack rules
            you can choose to only take one more card and stand doing this allows you to raise your bet but it's risky
            this is called Doubling down
            */
            playerHand.AddLast(dealersCards.Dequeue());
        }

        public void CardsBackToDealer(ref Queue<Card> dealerscards) //At the end of each players turn they pass back all cards to the dealer
        {
            foreach(Card card in playerHand)
            {
                dealerscards.Enqueue(card);
            }
            playerHand.Clear();
        }
        
    }
}
