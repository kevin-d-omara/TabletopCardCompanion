using System;
using System.Collections.Generic;
using System.Linq;

namespace TabletopCardCompanion.DataStructures
{
    /// <summary>
    /// Represents a stack-based collection of playing cards.
    /// Provides methods to shuffle and split the deck.
    /// </summary>
    public class Deck<TCard> : Stack<TCard>
    {
        /// <summary>
        /// Randomize the ordering of the cards.
        /// </summary>
        public void Suffle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Divide the deck into two halves.
        /// </summary>
        /// <returns>A tuple containing the top half of the deck followed by the bottom half.</returns>
        public Tuple<Deck<TCard>,Deck<TCard>> Split()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reverse the ordering of the cards.
        /// <para>
        /// For example, when flipping the deck over.
        /// </para>
        /// </summary>
        public void ReverseOrder()
        {
            var queue = new Queue<TCard>();
            while (Count > 0)
            {
                queue.Enqueue(Pop());
            }
            while (queue.Count > 0)
            {
                Push(queue.Dequeue());
            }
        }

        /// <summary>
        /// Add another deck on top of this one.
        /// <example>
        /// Deck1: A, B
        /// Deck2: C, D
        /// Deck1.Push(Deck2)   // Deck1: A, B, C, D
        /// </example>
        /// </summary>
        public void Push(IEnumerable<TCard> otherDeck)
        {
            otherDeck.Reverse().ToList().ForEach(Push);
        }
    }
}
