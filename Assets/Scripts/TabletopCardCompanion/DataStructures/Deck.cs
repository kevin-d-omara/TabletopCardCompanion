using System;
using System.Collections.Generic;

namespace TabletopCardCompanion.DataStructures
{
    /// <summary>
    /// Represents a stack-based collection of playing cards.
    /// </summary>
    public class Deck<TCard>
    {
        /// <summary>
        /// The number of cards in the deck.
        /// </summary>
        public int Count => cards.Count;

        private readonly Stack<TCard> cards = new Stack<TCard>();

        /// <summary>
        /// Return the top card of the deck.
        /// </summary>
        public TCard Draw()
        {
            return cards.Pop();
        }

        /// <summary>
        /// Add a card to the top of the deck.
        /// </summary>
        public void Add(TCard card)
        {
            cards.Push(card);
        }

        /// <summary>
        /// Return the top card of the deck without removing it from the collection
        /// </summary>
        public TCard Peek()
        {
            return cards.Peek();
        }

        /// <summary>
        /// Randomize the ordering of the cards.
        /// </summary>
        public void Suffle()
        {
            throw new NotImplementedException();
        }
    }
}
