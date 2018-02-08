using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        private Game game;
        private int playerCount = 1;
        private int turnCounts = 0;
        private Queue<Player> players = new Queue<Player>();

        private Card[] allTheCards = {
            new Card('H',"A"), new Card('H',"2"), new Card('H',"3"), new Card('H',"4"), new Card('H',"5"), new Card('H',"6"),
            new Card('H',"7"), new Card('H',"8"), new Card('H',"9"), new Card('H',"10"),new Card('H',"J"), new Card('H',"Q"), new Card('H',"K"),

            new Card('S',"A"), new Card('S',"2"), new Card('S',"3"), new Card('S',"4"), new Card('S',"5"), new Card('S',"6"),
            new Card('S',"7"), new Card('S',"8"), new Card('S',"9"), new Card('S',"10"),new Card('S',"J"), new Card('S',"Q"), new Card('S',"K"),

            new Card('C',"A"), new Card('C',"2"), new Card('C',"3"), new Card('C',"4"), new Card('C',"5"), new Card('C',"6"),
            new Card('C',"7"), new Card('C',"8"), new Card('C',"9"), new Card('C',"10"),new Card('C',"J"), new Card('C',"Q"), new Card('C',"K"),

            new Card('D',"A"), new Card('D',"2"), new Card('D',"3"), new Card('D',"4"), new Card('D',"5"), new Card('D',"6"),
            new Card('D',"7"), new Card('D',"8"), new Card('D',"9"), new Card('D',"10"),new Card('D',"J"), new Card('D',"Q"), new Card('D',"K"),
        };

        private Queue<Card> dealersCards = new Queue<Card>();
        public Game() {

            Console.Out.WriteLine();
            Console.Out.WriteLine("    <--BLACKJACK-->");
            Console.Out.WriteLine();

            Console.Out.Write("  How Many Players: ");
            playerCount = int.Parse(Console.In.ReadLine());



            CreateThePlayers(this.playerCount);
            
            StartGame();

        }

        public void CreateThePlayers(int ammountOfPlayers)
        {
            for (int i = 0; i < ammountOfPlayers; i++)
            {
                this.players.Enqueue(new Player());
            }
        }

        public void StartGame()
        {
            Shuffle();
            Deal();
        }

        public void ShowAllCards()
        {
            foreach (Card card in allTheCards)
            {
                card.Print();
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            Card[] ShuffledCards = allTheCards.OrderBy(x => rnd.Next()).ToArray();
            allTheCards = ShuffledCards;

            dealersCards = new Queue<Card>(allTheCards);
        }
        
        public void Deal()
        {
            Console.Clear();
            Console.Out.WriteLine();
            Console.Out.WriteLine("    " + players.Peek().GetName());
            Console.Out.WriteLine();
            players.Peek().GetDeal(ref dealersCards, ref players);
            Shuffle();
            if(players.Peek().Turn(ref dealersCards, ref players))
            {
                TurnOver();
            }
            else
            {
                Turn();
            }
        
        }

        public void Turn()
        {
            if(players.Peek().Turn(ref dealersCards, ref players))
            {
                TurnOver();
            }
            else
            {
                Turn();
            }
        }

        public void TurnOver() //Dequeue the player who just had their turn and put them at the start of the queue
        {
            turnCounts++;

            if(turnCounts == playerCount)
            {
                Console.Clear();
                //Show play who won round
                turnCounts = 0;
                Dictionary<String, int?> rosta = new Dictionary<String, int?>();
                foreach(Player player in players)
                {
                    rosta.Add(player.GetName(), player.GetScore());
                }
                var winner = from pair in rosta orderby pair.Value descending select pair;
                Console.Out.WriteLine();
                Console.Out.WriteLine("    Round Results");
                Console.Out.WriteLine();
                int count = 0;
                foreach(KeyValuePair<String,int?> pair in winner)
                {
                    if (pair.Value == 21) {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(pair.Value == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Out.Write("  " + pair.Key + ": " + pair.Value + " ");
                    count++;
                    if (count == 5)
                    {
                        Console.Out.WriteLine();
                        Console.Out.WriteLine();
                    }
                }
                
                Console.In.ReadLine();
            }

            Player turnOverPlayer = players.Dequeue();
            this.players.Enqueue(turnOverPlayer);
            Deal();
        }
    }
}
