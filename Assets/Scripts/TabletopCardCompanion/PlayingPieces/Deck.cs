using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.PlayingPieces;
using UnityEngine;

namespace TabletopCardCompanion
{
    public class Deck : PlayingPiece
    {
        private Stack<PlayingPiece> cards = new Stack<PlayingPiece>();

        /// <summary>
        /// Draw the top card of the deck.
        /// </summary>
        public PlayingPiece DrawCard()
        {
            var card = cards.Pop();
            card.gameObject.SetActive(true);
            MatchTransform(card);

            // If deck is empty, destroy the deck.
            if (cards.Count == 0)
            {
                Destroy(gameObject);
            }

            return card;
        }

        /// <summary>
        /// Place a card on top of the deck.
        /// </summary>
        public void AddCard(PlayingPiece card)
        {
            cards.Push(card);
            card.gameObject.SetActive(false);
            MatchTransform(card);
        }

        /// <summary>
        /// Match the position, rotation, and scale of the card to the deck.
        /// </summary>
        private void MatchTransform(PlayingPiece card)
        {
            card.transform.position = transform.position;
            // rotation
            // scale
        }



        // TEMPORARY -----------------------------------------------------------
        public PlayingPiece card0;
        public PlayingPiece card1;

        private void OnMouseOver()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                switch (cards.Count)
                {
                    case 0:
                        Debug.Log("add card 0");
                        AddCard(card0);
                        break;
                    case 1:
                        Debug.Log("add card 1");
                        AddCard(card1);
                        break;
                    default:
                        Debug.Log("too many/few cards");
                        break;
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                switch (cards.Count)
                {
                    case 1:
                        Debug.Log("remove card 0: " + DrawCard());
                        break;
                    case 2:
                        Debug.Log("remove card 1: " + DrawCard());
                        break;
                    default:
                        Debug.Log("too many/few cards");
                        break;
                }
            }
        }
    }
}
