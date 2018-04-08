using System;
using System.Collections.Generic;

namespace TabletopCardCompanion.DataStructures
{
    /// <summary>
    /// Represents a stack-based collection of playing cards.
    /// Provides methods to shuffle and split the deck.
    /// </summary>
    public class Deck<TCard> : Stack<TCard>
    {
        /// <summary>
        /// Randomize the order of the cards.
        /// </summary>
        public void Suffle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return both halves of the deck.
        /// </summary>
        /// <returns>A tuple containing the top half of the deck followed by the bottom half.</returns>
        public Tuple<Deck<TCard>,Deck<TCard>> Split()
        {
            throw new NotImplementedException();
        }
    }
}
