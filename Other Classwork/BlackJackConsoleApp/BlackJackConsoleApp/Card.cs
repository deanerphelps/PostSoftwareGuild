using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Value Value { get; set; }
        public bool IsFaceUp { get; set; }

        public Card()
        {
        }

        public Card(Value value, Suit suit, bool isFaceUp = false)
        {
            if (!Enum.IsDefined(typeof(Suit), suit))
            {
                throw new InvalidCardTypeException("Invalid suit");
            }
            if (!Enum.IsDefined(typeof(Value), value))
            {
                throw new InvalidCardTypeException("Invalid card");
            }

            Suit = suit;
            IsFaceUp = isFaceUp;
            Value = value;
        }

        public Card(string strCard, bool isFaceUp = false)
        {
            //Check for length
            if (strCard.Length >= 2 && strCard.Length <= 3)
            {
                switch (strCard.Substring(strCard.Length - 1, 1).ToUpper())
                {
                    case "H":
                        Suit = Suit.Heart;
                        break;

                    case "S":
                        Suit = Suit.Spade;
                        break;

                    case "C":
                        Suit = Suit.Club;
                        break;

                    case "D":
                        Suit = Suit.Diamond;
                        break;

                    default:
                        throw new InvalidCardTypeException("invalid suit");
                }
                IsFaceUp = isFaceUp;
                switch (strCard.Substring(0, strCard.Length - 1).ToUpper())
                {
                    case "2":
                        Value = Value.Two;
                        break;
                    case "3":
                        Value = Value.Three;
                        break;
                    case "4":
                        Value = Value.Four;
                        break;
                    case "5":
                        Value = Value.Five;
                        break;
                    case "6":
                        Value = Value.Six;
                        break;
                    case "7":
                        Value = Value.Seven;
                        break;
                    case "8":
                        Value = Value.Eight;
                        break;
                    case "9":
                        Value = Value.Nine;
                        break;
                    case "10":
                        Value = Value.Ten;
                        break;
                    case "J":
                        Value = Value.Jack;
                        break;
                    case "Q":
                        Value = Value.Queen;
                        break;
                    case "K":
                        Value = Value.King;
                        break;
                    case "A":
                        Value = Value.Ace;
                        break;

                    default:
                        throw new InvalidCardTypeException("invalid card value");
                }
            }
            else
            {
                throw new InvalidCardTypeException("Invalid card length");
            }
        }

        public override string ToString()
        {
            string[] strValues = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            return strValues[(int)Value - 1] + Suit.ToString().Substring(0, 1);
        }
    }
}

