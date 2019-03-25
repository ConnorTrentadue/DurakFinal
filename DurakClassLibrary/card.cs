/*
 * Card.cs - Card class for creating card objects.
 * 
 * Author: Raymond Michael
 * Since: 22 Mar 2019
 * 
 */

using System;
using System.Drawing;

namespace DurakClassLibrary
{
    public class Card : ICloneable, IComparable
    {
        #region FIELDS AND PROPERTIES

        protected Suit mySuit;
        public Suit Suit
        {
            get { return mySuit; }
            set { mySuit = value; }
        }

        protected Rank myRank;
        public Rank Rank
        {
            get { return myRank; }
            set { myRank = value; }
        }

        protected int myValue;
        public int CardValue
        {
            get { return myValue; }
            set { myValue = value; }
        }

        protected int? altValue = null;
        public int? AlternateValue
        {
            get { return altValue; }
            set { altValue = value; }
        }

        protected bool faceUp = false;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Card(Rank rank = Rank.Ace, Suit suit = Suit.Heart)
        {
            this.myRank = rank;
            this.mySuit = suit;
            this.myValue = (int)rank;
        }

        #endregion

        #region PUBLIC METHODS

        public virtual int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Unable to compare a card to a null object.");
            }

            Card compareCard = obj as Card;

            if (compareCard != null)
            {
                int thisSort = this.myValue * 10 + (int)this.mySuit;
                int compareCardSort = compareCard.myValue * 10 + (int)compareCard.mySuit;
                return (thisSort.CompareTo(compareCardSort));
            }
            else
            {
                throw new ArgumentException("Object being compared cannot be converted to a Card.");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            string cardString;

            if (faceUp)
            {
                cardString = myRank.ToString() + " of " + mySuit.ToString();
            }
            else
            {
                cardString = "Face Down";
            }

            return cardString;
        }

        public override bool Equals(object obj)
        {
            return (this.CardValue == ((Card)obj).CardValue);
        }

        public override int GetHashCode()
        {
            return this.myValue * 100 + (int)this.mySuit * 10 + ((this.faceUp) ? 1 : 0);
        }

        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;

            if (!faceUp)
            {
                imageName = "Back";
            }
            else
            {
                imageName = mySuit.ToString() + "_" + myRank.ToString();
            }

            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            return cardImage;
        }

        /// <summary>
        /// Trump suit assignment
        /// </summary>
        public static Suit trump = Suit.Club;

        public string DebugString()
        {
            string cardState = (string)(myRank.ToString() + " of " + mySuit.ToString().PadLeft(20));
            cardState += (string)((FaceUp) ? "(Face Up)" : "(Face Down)").PadLeft(12);
            cardState += " Value: " + myValue.ToString().PadLeft(2);
            cardState += ((altValue != null) ? "/" + altValue.ToString() : "");
            return cardState;
        }

        #endregion

        #region RELATIONAL OPERATORS

        public static bool operator ==(Card left, Card right)
        {
            return (left.CardValue == right.CardValue);
        }

        public static bool operator !=(Card left, Card right)
        {
            return (left.CardValue != right.CardValue);
        }

        public static bool operator <(Card left, Card right)
        {
            return (left.CardValue < right.CardValue);
        }

        public static bool operator <=(Card left, Card right)
        {
            return (left.CardValue <= right.CardValue);
        }

        public static bool operator >(Card left, Card right)
        {
            return (left.CardValue > right.CardValue);
        }

        public static bool operator >=(Card left, Card right)
        {
            return (left.CardValue >= right.CardValue);
        }

        #endregion
    }
}

