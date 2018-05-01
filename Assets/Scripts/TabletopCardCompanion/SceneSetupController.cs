using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.PlayingPieces;
using UnityEngine;

namespace TabletopCardCompanion
{
    /// <summary>
    /// For testing only. Sets up the scene by adding starting cards to the spawn deck.
    /// </summary>
    public class SceneSetupController : MonoBehaviour
    {
        [Serializable]
        public class DeckModel
        {
            [Header("Decks")]
            public Deck drawPile;

            [Header("Cards")]
            public Sprite backImage;
            public List<Sprite> frontImages;

            public void InitializeDeck()
            {
                foreach (var frontImage in frontImages)
                {
                    drawPile.Add(new CardModel(frontImage, backImage));
                    drawPile.Shuffle();
                }
            }
        }

        public List<DeckModel> decks = new List<DeckModel>();


        private void Start()
        {
            foreach (var deck in decks)
            {
                deck.InitializeDeck();
            }
        }
    }
}
