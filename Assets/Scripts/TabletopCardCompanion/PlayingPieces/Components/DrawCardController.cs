using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components
{
    /// <summary>
    /// Controls moving the top card of a deck to its discard pile.
    /// </summary>
    [RequireComponent(typeof(TapGesture))]
    public class DrawCardController : MonoBehaviour
    {
        [SerializeField] private Deck drawDeck;
        [SerializeField] private Deck discardPile;

        /// <summary>
        /// Draw a card from the draw deck and place it in the discard pile
        /// </summary>
        private void DrawCard()
        {
            var card = drawDeck.Draw();
            discardPile.Add(card);
            // TODO: Magnify drawn card.
        }

        private void TappedHanlder(object sender, EventArgs e)
        {
            if (drawDeck.Count > 0)
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
