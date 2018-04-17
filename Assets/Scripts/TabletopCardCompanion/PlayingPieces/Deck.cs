using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.DataStructures;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces
{
    /// <summary>
    /// A deck of cards.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Deck : MonoBehaviour
    {
        /// <summary>
        /// The number of cards in the deck.
        /// </summary>
        public int Count => cards.Count;

        [SerializeField] private bool isFaceUp = true;
        private readonly Deck<CardModel> cards = new Deck<CardModel>();

        /// <summary>
        /// Draw the top card of the deck.
        /// </summary>
        public CardModel Draw()
        {
            var topCard = cards.Draw();
            UpdateView();
            return topCard;
        }

        /// <summary>
        /// Add a card to the top of the deck.
        /// </summary>
        public void Add(CardModel card)
        {
            cards.Add(card);
            UpdateView();
        }

        /// <summary>
        /// Add a card to the bottom of the deck.
        /// </summary>
        public void AddToBottom(CardModel card)
        {
            cards.AddToBottom(card);
            UpdateView();
        }



        /// <summary>
        /// Randomize the ordering of the cards.
        /// </summary>
        public void Shuffle()
        {
            cards.Shuffle();
        }

        /// <summary>
        /// Make sure the correct card is showing.
        /// </summary>
        private void UpdateView()
        {
            if (cards.Count > 0)
            {
                var topCard = cards.Peek();
                spriteRenderer.sprite = isFaceUp ? topCard.Front : topCard.Back;
                boxCollider.size = spriteRenderer.sprite.bounds.size;
            }
            else
            {
                spriteRenderer.sprite = null;
            }
        }


        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }
}
