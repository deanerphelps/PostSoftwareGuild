using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Shoe
    {
        public const int NUMBER_OF_DECKS = 4;
        private const double THRESHOLD = 0.75;

        private Card[] cards;
        private int topCardIndex;
        Random random = new Random();
        public Shoe()
        {
            int cardCount = 0;
            Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));
            Value[] value = (Value[])Enum.GetValues(typeof(Value));

            cards = new Card[suits.Length * value.Length * NUMBER_OF_DECKS];

            for (int k = 0; k < NUMBER_OF_DECKS; ++k)
            {
                for (int j = 0; j < suits.Length; ++j)
                {
                    for (int i = 0; i < value.Length; ++i)
                    {
                        Card card = new Card(value[i], suits[j]);
                        cards[cardCount++] = card;
                    }
                }
            }
            Random random = new Random();
        }

        public void Shuffle(bool forceShuffle = false)
        {
            if ( forceShuffle || cards.Length * THRESHOLD <= topCardIndex)
            {
                for (int i = cards.Length -1; i > 0; --i)
                {
                    int index = random.Next(cards.Length - i);
                    Card temp = cards[cards.Length - i];
                    cards[cards.Length - i] = cards[index];
                    cards[index] = temp;
                }
                topCardIndex = 0;
            }
        }
        //////////////////////////////////
        
        public Card GetCard()
        {
            /*
            Card returnCard = null;
            if (topCardIndex < cards.Length)
            {
                returnCard = cards[topCardIndex++];
            }
            */

            
            if (topCardIndex == cards.Length)
            {
                return null;
            }
            return cards[topCardIndex++];           
        }
        
    }
}

//SHUFFLE THE DECKS OF CARDS
