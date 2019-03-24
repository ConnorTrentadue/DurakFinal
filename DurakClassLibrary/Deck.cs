﻿/*
 * Deck.cs - Deck class for creating card objects for Durak Games
 * 
 * Author: Shaun McCrum
 * Since: 22 Mar 2019
 * See: Watson, K. (2013). Beginning Visual C♯® 2012 programming. Indianapolis, IN: John Wiley & Sons.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class Deck : ICloneable
    {
        //craetes the custom event handler
        public event EventHandler LastCardDrawn;

        private Cards cards = new Cards();

        public Deck()
        {
            // cards = new Card[];
            for (int suitValue = 0; suitValue < 4; suitValue++)
            {
                for (int rankValue = 5; rankValue < 15; rankValue++)
                {
                    // assign cards a unique value  (obsolete)
                    //cards[suitValue * 13 + rankValue - 1] = new Card((Suit)suitValue, 
                    //    (Rank)rankValue);
                    cards.Add(new Card((Suit)suitValue, (Rank)rankValue));
                }
            }

        }
        
        public void Shuffle()
        {
            // create temp card array
            //Card[] newDeck = new Card[36];
            Cards newDeck = new Cards();    // create new collection of cards
            bool[] assigned = new bool[36]; // durak deck size
            Random sourceGen = new Random();      // for generating random numbers

            // loop through the card array looking for a card
            for (int i = 0; i < 36; i++)
            {
                //int destCard = 0;
                int sourceCard = 0;
                bool foundCard = false;
                // loop to look and see if a card has been found in the temporary deck
                while (foundCard == false)
                {
                    //destCard = sourceGen.Next(36);      //defines the random number for the temp card array
                    sourceCard = sourceGen.Next(36);
                    if (assigned[sourceCard] == false)    // check if the current random value was assigned or not
                    {
                        foundCard = true;
                    }
                }
                // assigns the current bool to true and copies the card value into the temporary deck
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);     //add the source card to the collection
            }
            // copies each card in the newDeack back into the cards array replacing the original deck.
            newDeck.CopyTo(cards);
        }

        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        private Deck(Cards newCards)
        {
            cards = newCards;
        }


        /// <summary>
        /// Non default constructor, set trump
        /// </summary>
        /// <param name="useTrump">to hold status if this a card is trump</param>
        /// <param name="trump">the suit value of the trump</param>
        public Deck(Suit trump) : this()
        {
            Card.trump = trump;
        }



        /// <summary>
        /// Method to create a method to test Expanding
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null))
                    //Call the custom event handler when last card is drawn
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException((Cards)cards.Clone());
        }
    }
}