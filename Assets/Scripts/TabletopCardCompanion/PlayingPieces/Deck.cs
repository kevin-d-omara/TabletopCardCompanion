using System;
using System.Linq;
using TabletopCardCompanion.DataStructures;

namespace TabletopCardCompanion.PlayingPieces
{
    /// <summary>
    /// Represents a stack-based collection of cards.
    /// </summary>
    public class Deck : PlayingPiece
    {
        // TODO: TEMPORARY -- just here to work out how to transfer "click" between the deck and the new card (i.e. for dragging a card off of the top).
        // TODO: Figure out how to differentiate between a "quick drag" (for taking a card off), and a "pause-then-drag" (for moving the whole deck).
//        private void OnMouseDown()
//        {
//            Take();
//        }

        private readonly Deck<PlayingPiece> cards = new Deck<PlayingPiece>();

        /// <summary>
        /// Take the top card off of the deck.
        /// </summary>
        public PlayingPiece Take()
        {
            var card = Pop();
            UpdateView();
            return card;
        }

        /// <summary>
        /// Add a card or deck of cards to the top of the deck.
        /// </summary>
        public void Add(PlayingPiece piece)
        {
            var type = piece.GetType();
            if (type == typeof(Deck))
            {
                var otherDeck = piece.GetComponent<Deck>();
                var otherCards = otherDeck.cards.Reverse();
                foreach (var card in otherCards)
                {
                    Push(card);
                }
                Destroy(piece.gameObject);
            }
            else if (type == typeof(Card))
            {
                Push(piece);
            }
            else
            {
                throw new InvalidOperationException("Cannot add " + piece + " to the deck. It is not a " + typeof(Card) + " or a " + typeof(Deck) + ", it is a " + type + ".");
            }

            UpdateView();
        }

        /// <summary>
        /// Randomize the ordering of the cards.
        /// </summary>
        public void Shuffle()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// If the object placed above is a <see cref="Card"/> or <see cref="Deck"/>, then add it to the top of this deck.
        /// </summary>
        /// <param name="objAbove">Object placed above this one.</param>
        protected override void NotifyRecipientOfPlacement(PlayingPiece objAbove)
        {
            var aboveType = objAbove.GetType();
            if (aboveType == typeof(Card) || aboveType == typeof(Deck))
            {
                Add(objAbove);
            }
        }

        /// <summary>
        /// Push a card onto the stack and de-activate its game object.
        /// </summary>
        private void Push(PlayingPiece card)
        {
            cards.Push(card);
            card.gameObject.SetActive(false);
        }

        /// <summary>
        /// Pop the top card off of the stack and re-activate its game object.
        /// </summary>
        /// <returns></returns>
        private PlayingPiece Pop()
        {
            var card = cards.Pop();
            card.gameObject.SetActive(true);
            return card;
        }

        /// <summary>
        /// Make sure the top card is showing.
        /// <para>
        /// Accounts for which side of the deck is face up and which side of the individual card is face up.
        /// </para>
        /// </summary>
        private void UpdateView()
        {
            var card = cards.Peek();
            TwoSidedSprite.SetFrontAndBack(card.TwoSidedSprite);

            // TODO: Show the backside if the card is placed in the deck already flipped over.
        }
    }
}
