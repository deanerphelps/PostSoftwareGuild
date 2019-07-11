using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BlackJackConsoleApp;

namespace BlackJackConsoleApp.Tests
{
    [TestFixture]
    public class ShoeTests
    {
        [Test]
        public void GetAllCards()
        {
            int numOfCards = 0;
            Shoe shoe = new Shoe();
            Dictionary<string, int> cardCounter = new Dictionary<string, int>();
            Card card;

            shoe.Shuffle(true);

            while((card = shoe.GetCard()) != null)
            {
                string cardKey = card.ToString();
 
                if (cardCounter.ContainsKey(cardKey))
                {
                    ++cardCounter[cardKey];
                }
                else
                {
                    //cardCounter[cardKey] = 1;
                    cardCounter.Add(cardKey, 1);
                }                
                ++numOfCards;
            }
            ///////////////////////////////////////
            string[] keys = cardCounter.Keys.ToArray();

            Assert.AreEqual(52, keys.Length);
            for (int i = 0; i < keys.Length; ++i)
            {
                Assert.AreEqual(Shoe.NUMBER_OF_DECKS, cardCounter[keys[i]]);
            }
            Assert.AreEqual(Shoe.NUMBER_OF_DECKS * 52, numOfCards);
            ///////////////////////////////////////
            Assert.IsTrue(cardCounter.All(cc => cc.Value == Shoe.NUMBER_OF_DECKS));
        }
    }
}
