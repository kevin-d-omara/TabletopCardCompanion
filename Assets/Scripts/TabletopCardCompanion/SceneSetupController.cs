using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.Models;
using TabletopCardCompanion.PlayingPieces;
using UnityEngine;

namespace TabletopCardCompanion
{
    /// <summary>
    /// For testing only. Populates a single tab with the provided decks.
    /// </summary>
    public class SceneSetupController : MonoBehaviour
    {
        [Serializable]
        public class DeckModel
        {
            [Header("Cards")]
            public Sprite backImage;
            public List<Sprite> frontImages;

            public void AddCardsToDeck(Deck drawPile)
            {
                foreach (var frontImage in frontImages)
                {
                    drawPile.Add(new CardModel(frontImage, backImage));
                    drawPile.Shuffle();
                }
            }
        }

        [Header("References")]
        public GameObject canvasRoot;

        [Header("Prefabs")]
        public GameObject drawPilePrefab;
        public GameObject discardPilePrefab;
        public GameObject tabPanelPrefab;

        [Header("Decks")]
        public List<DeckModel> decks = new List<DeckModel>();

        private void Start()
        {
            // Create a new tab.
            var tabPanel = Instantiate(tabPanelPrefab, canvasRoot.transform);
            var fullscreenRow = tabPanel.transform.Find("Fullscreen Row");      // HACK --> in future use "tabPanelController"

            // Create draw piles for each deck (in fullscreen row) (no discard pile for now).
            foreach (var deckModel in decks)
            {
                var drawPile = Instantiate(drawPilePrefab, fullscreenRow.transform);
                var deck = drawPile.GetComponent<Deck>();
                deckModel.AddCardsToDeck(deck);
            }
        }
    }
}
