using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Hand
    {
        private List<Card> cards;
        public GameResult GameResult { get; set; }

        public Hand()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// Take the given card and add to the hand
        /// </summary>
        /// <param name="card">Newly delt card</param>
        public void TakeCard(Card card)
        {
            cards.Add(card);
            if (cards.Count == 2 && GetScore() == Table.BLACKJACK)
            {
                GameResult = GameResult.Blackjack;
            }
            else if (GetScore() > Table.BLACKJACK)
            {
                GameResult = GameResult.Bust;
            }
        }

        /// <summary>
        /// After a round is played, clear the cards
        /// </summary>
        public void ReturnCards()
        {
            cards.Clear();
        }

        /// <summary>
        /// Get the collection of cards in the hand
        /// </summary>
        /// <returns>Array of cards in the hand</returns>
        public Card[] GetCards()
        {
            return cards.ToArray();
        }

        public int GetScore()
        {
            int score = 0;
            int numAces = 0;

            for (int i = 0; i < cards.Count; ++i)
            {
                Card card = cards[i];

                switch (card.Value)
                {
                    // Aces are initially worth 1
                    case Value.Ace:
                        score += 1;
                        ++numAces;
                        break;

                    case Value.Jack:
                    case Value.Queen:
                    case Value.King:
                        score += 10;
                        break;

                    default:
                        score += (int)card.Value;
                        break;
                }
            }

            // If there are any aces and changing
            // an ace to 11 will not go bust, adjust
            // the score to have 1 ace be 11.
            if (numAces > 0 && score <= 11)
            {
                score += 10;
            }

            return score;
        }
    }
}