/*
 * StandardDeck.cs - Standard 52 card deck class.  Can be used to initiate other deck sizes.
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
        /// Creates a clode of a cards object.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }
    }
}
