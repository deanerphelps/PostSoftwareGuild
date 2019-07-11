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
    class CardTests
    {
        // Create an individual card by string
        [Test]
        public void CreateIndiviudalCardByString()
        {
            Card card = new Card("10S");
            Assert.IsNotNull(card);
            Assert.AreEqual(Value.Ten, card.Value);
            Assert.AreEqual(Suit.Spade, card.Suit);
        }

        // Create an individual card by using enums
        [Test]
        public void CreateIndividualCardByEnum()
        {
            Card card = new Card(Value.Ten, Suit.Spade);
            Assert.IsNotNull(card);
            Assert.AreEqual(Value.Ten, card.Value);
            Assert.AreEqual(Suit.Spade, card.Suit);
        }

        // Create valid cards using simple test cases
        [TestCase(Value.Ace, Suit.Diamond)]
        [TestCase(Value.Ten, Suit.Heart)]
        [TestCase(Value.Ten, Suit.Club)]
        [TestCase(Value.Ten, Suit.Spade)]
        [TestCase(Value.Ten, Suit.Diamond)]
        public void CreateCardTest(Value cardFaceValue, Suit suit)
        {
            Card card = new Card(cardFaceValue, suit);
            Assert.IsNotNull(card);
            Assert.AreEqual(cardFaceValue, card.Value);
            Assert.AreEqual(suit, card.Suit);
        }

        // Negative tests using simple test cases
        [TestCase("2")]     // No suit
        [TestCase("")]      // blank
        [TestCase("2Z")]    // invalid suit
        [TestCase("1H")]    // invalid card
        [TestCase("FAIL")]  // all junk
        [TestCase("22")]    // invalid suit
        [TestCase(" 2D ")]  // too long (spaces - bad)
        public void FailCreateCardByString(string str)
        {
            // delegate - a block of code to exectute could be inline code (as-is)
            // or a function to be called.
            Assert.Catch(typeof(InvalidCardTypeException), delegate { new Card(str); });
        }

        // Exhaustive (full deck) of cards by string using combinatorial to matrix both card value & suit
        [Test, Combinatorial]
        public void CreateAllCardsByString(
            [Values("2", "3", "4", "5", "6", "7", "8", "9", "10", "j", "Q", "k", "A")] string strValue,
            [Values("D", "h", "c", "S")] string strSuit)
        {
            Card card = new Card(strValue + strSuit);
            switch (strSuit.ToUpper())
            {
                case "D":
                    Assert.AreEqual(Suit.Diamond, card.Suit);
                    break;
                case "H":
                    Assert.AreEqual(Suit.Heart, card.Suit);
                    break;
                case "C":
                    Assert.AreEqual(Suit.Club, card.Suit);
                    break;
                case "S":
                    Assert.AreEqual(Suit.Spade, card.Suit);
                    break;
                default:
                    Assert.Fail();
                    break;
            }
            int val;
            if (int.TryParse(strValue, out val))
            {
                Assert.AreEqual((Value)val, card.Value);
            }
            else
            {
                switch (strValue.ToUpper())
                {
                    case "A":
                        Assert.AreEqual(Value.Ace, card.Value);
                        break;
                    case "J":
                        Assert.AreEqual(Value.Jack, card.Value);
                        break;
                    case "Q":
                        Assert.AreEqual(Value.Queen, card.Value);
                        break;
                    case "K":
                        Assert.AreEqual(Value.King, card.Value);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
        }

        // Exhaustive (full deck) of cards by enums using combinatorial to matrix both card value & suit
        [Test, Combinatorial]
        public void CreateAllCardsByEnum(
            [Values(
                Value.Ace,
                Value.Two,
                Value.Three,
                Value.Four,
                Value.Five,
                Value.Six,
                Value.Seven,
                Value.Eight,
                Value.Nine,
                Value.Ten,
                Value.Jack,
                Value.Queen,
                Value.King
            )] Value cardFaceValue,
            [Values(Suit.Club, Suit.Diamond, Suit.Heart, Suit.Spade)] Suit suit)
        {
            Card card = new Card(cardFaceValue, suit);
            Assert.AreEqual(suit, card.Suit);
            Assert.AreEqual(cardFaceValue, card.Value);
        }

        // Negative tests for creating cards with invalid enum values
        [TestCase(((int)Value.King) * 2, (int)Suit.Club)]   // CardFaceValue is out of range
        [TestCase((int)Value.Ace, ((int)Suit.Spade) * 2)]   // Suit is out of range
        public void FailCreateCardByEnums(int faceValueInt, int suitInt)
        {
            Assert.Catch(typeof(InvalidCardTypeException), delegate { new Card((Value)faceValueInt, (Suit)suitInt); });
        }
    }
}