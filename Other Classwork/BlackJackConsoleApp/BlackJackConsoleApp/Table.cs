using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Table
    {
        const int MAX_NUM_OF_PLAYERS = 5;
        const decimal MIN_BANKROLL = 5M;
        const decimal MIN_BET = 2M;
        const int DEALER_STANDS_ON = 17;

        public const int BLACKJACK = 21;

        private Dealer dealer;
        private Shoe shoe;
        private Player[] players;

        public Table()
        {
            dealer = new Dealer();
            shoe = new Shoe();
            shoe.Shuffle(true);
            players = new Player[MAX_NUM_OF_PLAYERS];
        }

        private void SetupTable()
        {
            dealer.Name = "Dealer";
        }

        private Player GetPlayerFromConsole()
        {
            Player player = null;

            // Get player's name
            Console.WriteLine("Player's name? ");
            string playerName = Console.ReadLine();

            // If not empty, get their bankroll
            if (playerName.Trim().Length > 0)
            {
                decimal bankroll = Input.GetDecimalFromUser(
                    $"Player's bankroll (minimum ${MIN_BANKROLL})? ",
                    MIN_BANKROLL,
                    decimal.MaxValue
                );

                // Create new player
                player = new Player()
                {
                    Name = playerName,
                    Bankroll = bankroll
                };
            }

            return player;
        }

        private void AddPlayers()
        {
            int seatNum = 0;
            Player player = null;

            while (seatNum < MAX_NUM_OF_PLAYERS && (player = GetPlayerFromConsole()) != null)
            {
                players[seatNum++] = player;
            }
        }

        private void PlayGame()
        {
            // Shuffle
            shoe.Shuffle();

            // Get Bets
            foreach (Player player in players.Where(p => p != null && p.Bankroll > MIN_BET))
            {
                do
                {
                    player.Hand.ReturnCards();   //These two lines return play and dealer cards
                    dealer.Hand.ReturnCards();
                    player.Hand.GameResult = GameResult.None;  //These two lines reset game status
                    dealer.Hand.GameResult = GameResult.None;
                    //TODO \\MAKE THIS WORK// player.Bankroll = player.Bankroll - player.Wager;  //This line subtracts player wager from bet the NEXT round. Can't add yet

                    player.Wager = Input.GetIntFromUser($"{player.Name}, what is your bet?", 0, (int)player.Bankroll);
                } while (player.Wager > 0 && player.Wager < MIN_BET);
            }

            // Deal
            for (int i = 0; i < 2; ++i)
            {
                // give card to each player (all face up)
                foreach (Player player in players.Where(p => p != null && p.Wager > 0))
                {
                    Card card = shoe.GetCard();
                    card.IsFaceUp = true;
                    player.Hand.TakeCard(card);
                }
                // give card to dealer (first one face down)
                Card dealerCard = shoe.GetCard();
                dealerCard.IsFaceUp = (i == 1);
                dealer.Hand.TakeCard(dealerCard);
            }
            DisplayTable();

            // Play each hand
            foreach (Player player in players.Where(
                p => p != null
                && p.Wager > 0
                && p.Hand.GameResult != GameResult.Blackjack))
            {
                PlayHand(player);
            }
            PlayDealerHand();

            // Show results
            DisplayTable();
        }

        private bool PlayerWantsCard(Player player)
        {
            return Input.GetBoolFromUser($"{player.Name}, do you want to hit?");
        }

        public void PlayHand(Player player)
        {
            // while player is not bust && wants to take a card
            //    !isBust -> ask to take a card
            while (player.Hand.GameResult != GameResult.Bust && PlayerWantsCard(player))
            {
                // take a card
                Card card = shoe.GetCard();
                card.IsFaceUp = true;
                player.Hand.TakeCard(card);

                // display result
                DisplayTable();
            }
        }

        private void PlayDealerHand()
        {
            IEnumerable<Player> playersRemaining = players.Where(p => p != null && p.Wager > 0 && p.Hand.GameResult == GameResult.None);

            if (playersRemaining.Count() > 0)
            {
                // play dealer hand
                dealer.Hand.GetCards()[0].IsFaceUp = true;
                while (dealer.Hand.GetScore() < DEALER_STANDS_ON)
                {
                    Card card = shoe.GetCard();
                    card.IsFaceUp = true;
                    dealer.Hand.TakeCard(card);
                }

                int dealerScore = dealer.Hand.GetScore();
                foreach (Player player in playersRemaining)
                {
                    if (dealer.Hand.GameResult == GameResult.Bust)
                    {
                        // everyone wins
                        player.Hand.GameResult = GameResult.Win;
                    }
                    else
                    {
                        int playerScore = player.Hand.GetScore();

                        if (dealerScore == playerScore)
                        {
                            player.Hand.GameResult = GameResult.Push;
                        }
                        else if (dealerScore > playerScore)
                        {
                            player.Hand.GameResult = GameResult.Lose;
                        }
                        else
                        {
                            player.Hand.GameResult = GameResult.Win;
                        }
                    }               
                }                
            }
        }

        private void DisplayHand(string name, decimal? bankroll, decimal? wager, Hand hand)
        {
            // Display name
            Console.Write(name);
            if (wager != null)
            {
                Console.Write($"(${bankroll}), bet ${wager}");
            }
            Console.WriteLine();

            // Display cards
            foreach (Card card in hand.GetCards())
            {
                Console.Write($"{card} ");
            }
            Console.WriteLine();

            // Display total
            if (hand.GetCards().All(c => c.IsFaceUp))
            {
                Console.WriteLine($"Score: {hand.GetScore()}\n");
            }

            // Display result (win, lose, push, blackjack...)
            if (hand.GameResult != GameResult.None)
            {
                Console.WriteLine(hand.GameResult);
            }
        }

        private void DisplayTable()
        {
            Console.Clear();
            // Display dealer's hand
            DisplayHand(dealer.Name, null, null, dealer.Hand);

            // Display players' hand
            foreach (Player player in players.Where(p => p != null))
            {
                DisplayHand(player.Name, player.Bankroll, player.Wager, player.Hand);
            }
        }

        private void CheckTotal(Hand hand, string[] cards, int expectedResult)
        {
            hand.ReturnCards();
            for (int i = 0; i < cards.Length; ++i)
            {
                Card card = new Card(cards[i]);
                hand.TakeCard(card);
                Console.Write($"{card} ");
            }
            Console.WriteLine("\nHand expected value is " + expectedResult);
            Console.WriteLine("Hand value is " + hand.GetScore());
        }

        private bool PlayAgain()
        {
            return true;
        }

        public void Execute()
        {
            SetupTable();
            AddPlayers();
            
            while (PlayAgain())
            {
                PlayGame();
            }        
        }
    }
}