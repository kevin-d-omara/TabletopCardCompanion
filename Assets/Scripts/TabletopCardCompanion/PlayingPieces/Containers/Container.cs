using System.Collections.Generic;
using TabletopCardCompanion.DataStructures;

namespace TabletopCardCompanion.PlayingPieces.Containers
{
    /// <summary>
    /// A stack based collection of playing pieces.
    /// <para>
    /// For example, a deck of cards, stack of tiles, or bag of items.
    /// </para>
    /// </summary>
    public class Container : PlayingPiece
    {
        private Deck<PlayingPiece> elements = new Deck<PlayingPiece>();

        /// <summary>
        /// Take an element off the top of the container.
        /// </summary>
        public PlayingPiece Take()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Add an element to the top of the container.
        /// </summary>
        public void Add(PlayingPiece piece)
        {
            // # Make sure to check if the added piece is already a container.
            // if (piece == Container)
            //      foreach (element in container)
            //          self.add(element)
            // else
            //      push(piece)
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Randomize the order of the elements.
        /// </summary>
        public void Shuffle()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Create a new container from the two elements.
        /// If the first element is already a container, simply add the second element to it instead.
        /// </summary>
        /// <param name="first">First element to add to the container.</param>
        /// <param name="second">Second element to add to the container. Will be above the first element.</param>
        /// <returns>The new container, or the first element if it is already a container.</returns>
        public static Container CreateFrom(PlayingPiece first, PlayingPiece second)
        {
            // TODO: should this method actually return the created container?
            // TODO: Decide whether to deactivate elements or to serialize and destroy them.
            // if (first == Container)
            //      first.Add(second)
            //      return first
            // else
            //      var container = CreateGameObject(Container)
            //      container.Add(first)
            //      container.Add(second)
            //      return container

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Make sure the top card is showing.
        /// <para>
        /// Accounts for which side of the deck is face up and which side of the individual card is face up.
        /// </para>
        /// </summary>
        private void UpdateSprite()
        {
            throw new System.NotImplementedException();
        }
    }
}