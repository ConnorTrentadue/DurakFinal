/*
 * Cards.cs - Class for cloning Card objects into object of multiple cards.
 * 
 * Author: Shaun McCrum
 * Since: 22 Mar 2019
 * See: Watson, K. (2013). Beginning Visual C♯® 2012 programming. Indianapolis, IN: John Wiley & Sons.
 * 
 */

using System;
using System.Collections.Generic;       //List 


namespace DurakClassLibrary
{
    public class Cards : List<Card>, ICloneable
    { 
        /// <summary>
        /// Method for copying a card instance to another Cards object
        /// Used by Deck.Shuffle(). Implementation assumes source and target are sized identaically
        /// </summary>
        /// <param name="targetCards">the copied card index</param>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                // set the card to the current card in the index
                targetCards[index] = this[index];
            }
        }

        /// <summary>
        /// Method to clone an object.
        /// </summary>
        /// <returns>a new object of cards called newCards</returns>
        public object Clone()
        {
            // create a new Cards object
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                // add a clone of a card object to the newCards object.
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }
    }
}
