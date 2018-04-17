using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components
{
    /// <summary>
    /// Offers various methods for drawing a card from the top of a deck.
    /// </summary>
    [RequireComponent(typeof(TapGesture))]
    public class DrawCardController : MonoBehaviour
    {
        /// <summary>
        /// Controls what happens to the card that was drawn.
        /// </summary>
        public enum Mode
        {
            /// <summary>
            /// Place the drawn card in the discard pile.
            /// </summary>
            ToDiscard,

            /// <summary>
            /// Place the drawn card on the bottom of the draw pile.
            /// </summary>
            ToBottom,

            /// <summary>
            /// Shuffle the drawn card back into the deck.
            /// </summary>
            ShuffleBackIn,

            /// <summary>
            /// Destroy the drawn card.
            /// </summary>
            Destroy
        }

        [SerializeField] private Mode mode;
        [SerializeField] private Deck drawPile;
        [SerializeField] private Deck discardPile;

        /// <summary>
        /// Draw the top card from the draw pile, magnify it, then do something based on the <see cref="Mode"/>.
        /// </summary>
        private void DrawCard()
        {
            var card = drawPile.Draw();
            // TODO: Magnify drawn card.

            switch (mode)
            {
                case Mode.ToDiscard:
                    discardPile.Add(card);
                    break;
                case Mode.ToBottom:
                    drawPile.AddToBottom(card);
                    break;
                case Mode.ShuffleBackIn:
                    drawPile.Add(card);
                    drawPile.Shuffle();
                    break;
                case Mode.Destroy:
                    // Do nothing with the card. It will no longer exist in any deck.
                    break;
                default:
                    throw new InvalidOperationException("This line should never be reached.");
            }
        }

        private void TappedHanlder(object sender, EventArgs e)
        {
            if (drawPile.Count > 0)
            {
                DrawCard();
            }
        }

        private void OnEnable()
        {
            GetComponent<TapGesture>().Tapped += TappedHanlder;
        }

        private void OnDisable()
        {
            GetComponent<TapGesture>().Tapped -= TappedHanlder;
        }
    }
}
