﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces
{
    public class Card : PlayingPiece
    {
        [SerializeField]
        private GameObject deckPrefab;

        /// <summary>
        /// If the object placed above is a <see cref="Card"/> or <see cref="Deck"/>, then combine both together in a new deck.
        /// </summary>
        /// <param name="objAbove">Object placed above this one.</param>
        protected override void NotifyRecipientOfPlacement(PlayingPiece objAbove)
        {
            var aboveType = objAbove.GetType();
            if (aboveType == typeof(Card) || aboveType == typeof(Deck))
            {
                var deckObj = Instantiate(deckPrefab, transform.position, transform.rotation);
                var deck = deckObj.GetComponent<Deck>();
                deck.Add(this);
                deck.Add(objAbove);
            }
        }
    }
}
