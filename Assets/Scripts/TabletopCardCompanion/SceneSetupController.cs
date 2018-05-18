﻿using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.Controllers;
using TabletopCardCompanion.DataStructures;
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

            public void AddCardsToDeck(DeckController drawPile)
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
        public List<DeckModel> deckLists = new List<DeckModel>();

        private void Start()
        {
            // Create a new tab.
            var tabPanel = Instantiate(tabPanelPrefab, canvasRoot.transform);
            var fullscreenRow = tabPanel.transform.Find("Fullscreen Row");      // HACK --> in future use "tabPanelController"

            // Create draw piles for each deck (in fullscreen row) (no discard pile for now).
            foreach (var deckModel in deckLists)
            {
                var drawPile = Instantiate(drawPilePrefab, fullscreenRow.transform);
                var deck = drawPile.GetComponent<DeckController>();
                deckModel.AddCardsToDeck(deck);
            }
        }

        private void InitializeTabController()
        {
            // Create a new tab.
            var tabPanel = Instantiate(tabPanelPrefab, canvasRoot.transform);

            // Get reference to Controller.
            var tabController = tabPanel.GetComponent<TabController>();

            // Create decks.
            var deckPairs = new List<DeckPairModel>();
            foreach (var deckList in deckLists)
            {
                var drawPile = new Deck<CardModel>();
                var discardPile = new Deck<CardModel>();

                // Add cards from decklist into drawPile. (see AddCardsToDeck() method).
            }
        }
    }
}
