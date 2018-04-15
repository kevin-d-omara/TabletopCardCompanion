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
        [Header("Deck")]
        public Deck drawDeck;

        [Header("Cards")]
        public Sprite backImage;
        public List<Sprite> frontImages;

        private void Start()
        {
            foreach (var frontImage in frontImages)
            {
                drawDeck.Add(new CardModel(frontImage, backImage));
                drawDeck.Shuffle();
            }
        }
    }
}
