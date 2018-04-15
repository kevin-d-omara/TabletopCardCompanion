using System;
using System.Collections.Generic;

namespace TabletopCardCompanion.DataStructures
{
    /// <summary>
    /// Represents a collection of playing cards.
    /// <remarks>
    /// The deck is backed by a list to facilitate efficient shuffling.
    /// Both stack and list have O(1) performance for adding and removing at the end.
    /// A lists can be shuffled in place in O(n) time and space. A stack must first be copied to an array, cleared, and then re-pushed.
    /// </remarks>
    /// </summary>
    public class Deck<TCard>
    {
        /// <summary>
        /// The number of cards in the deck.
        /// </summary>
        public int Count => cards.Count;

        private readonly List<TCard> cards = new List<TCard>();

        /// <summary>
        /// Return the top card of the deck.
        /// </summary>
        public TCard Draw()
        {
            var lastCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return lastCard;
        }

        /// <summary>
        /// Add a card to the top of the deck.
        /// </summary>
        public void Add(TCard card)
        {
            cards.Add(card);
        }

        /// <summary>
        /// Return the top card of the deck without removing it from the collection
        /// </summary>
        public TCard Peek()
        {
            return cards[cards.Count - 1];
        }

        /// <summary>
        /// Randomize the ordering of the cards.
        /// </summary>
        public void Shuffle()
        {
            cards.Shuffle();
        }
    }
}
