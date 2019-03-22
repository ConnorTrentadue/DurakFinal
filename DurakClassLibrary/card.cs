/*
 * Card.cs - Card class for creating card objects.
 * 
 * Author: Raymond Michael
 * Since: 22 Mar 2019
 * See: Watson, K. (2013). Beginning Visual C♯® 2012 programming. Indianapolis, IN: John Wiley & Sons.
 * 
 */

using System;

namespace DurakClassLibrary
{
    public class Card : ICloneable
    {
        public readonly Rank rank;
        public readonly Suit suit;

        public static bool useTrumps = false;

        public static Suit trump = Suit.Club;

        public static bool isAceHigh = true;

        private Card()
        {
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }

        public static bool operator >(Card card1, Card card2)
        {
            bool isGreater = true;

            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                            isGreater = false;
                        else
                            isGreater = true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                        {
                            isGreater = false;
                        }
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))                
                    isGreater = false;                
                else
                    isGreater = true;
            }

            return isGreater;
        }

        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        public static bool operator >=(Card card1, Card card2)
        {
            bool isGreaterEqual = true;

            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        isGreaterEqual = true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                        {
                            isGreaterEqual = false;
                        }
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                {
                    isGreaterEqual = false;
                }
            }

            return isGreaterEqual;
        }

        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }
    }
}

