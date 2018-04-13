using System;
using TabletopCardCompanion.DataStructures;
using TouchScript;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces
{
    /// <summary>
    /// Represents a stack-based collection of cards.
    /// </summary>
    public class Deck : PlayingPiece
    {
        private TransformGesture transformGesture;

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
                cards.Push(otherDeck.cards);
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

        public override void FlipOver()
        {
            base.FlipOver();
            cards.ReverseOrder();
            UpdateView();
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
        /// Pop the top card off of the stack and update the card's view.
        /// If the final card is removed, destroy the deck.
        /// <para>
        /// The card is re-activated and its position, rotation, and scale are updated to match the deck.
        /// </para>
        /// </summary>
        private PlayingPiece Pop()
        {
            var card = cards.Pop();
            card.gameObject.SetActive(true);

            // Update the card's view. Match its position, rotation, and scale to the deck.
            card.transform.position = transform.position;
            // TODO: Match rotation and scale too.
            card.TwoSidedSprite.IsFaceUp = TwoSidedSprite.IsFaceUp;

            if (cards.Count == 0)
            {
                // Destroy is delayed to allow gesture control to be handed off to the most recently popped card.
                Destroy(gameObject, Mathf.Epsilon);
            }

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
            if (cards.Count == 0)
            {
                return;
            }

            var card = cards.Peek();
            TwoSidedSprite.SetFrontAndBack(card.TwoSidedSprite);

            // TODO: Show the backside if the card is placed in the deck already flipped over.
        }

        /// <summary>
        /// Fires when the deck starts moving. If the deck was picked up first (i.e. long-hold), then move the deck.
        /// Otherwise, stop moving the deck, spawn the top card of the deck, and move that card instead.
        /// </summary>
        private void TransformStartedHandler(object sender, EventArgs e)
        {
            var card = Take();

            // Stop moving the deck. Instead, move the card.
            LayerManager.Instance.SetExclusive(card.transform);
            transformGesture.Cancel(true, true);
            LayerManager.Instance.ClearExclusive();
        }

        protected override void Awake()
        {
            base.Awake();
            transformGesture = GetComponent<TransformGesture>();
        }


        private void OnEnable()
        {
            transformGesture.TransformStarted += TransformStartedHandler;
        }

        private void OnDisable()
        {
            transformGesture.TransformStarted -= TransformStartedHandler;
        }
    }
}
