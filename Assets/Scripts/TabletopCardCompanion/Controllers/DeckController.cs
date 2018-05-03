using TabletopCardCompanion.DataStructures;
using TabletopCardCompanion.Models;
using UnityEngine;
using UnityEngine.UI;

namespace TabletopCardCompanion.Controllers
{
    /// <summary>
    /// Controller for a deck of cards.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class DeckController : MonoBehaviour
    {
        /// <summary>
        /// The number of cards in the deck.
        /// </summary>
        public int Count => cards.Count;

        [SerializeField] private bool isFaceUp = true;  // TODO: Move faceup/facedown to DeckModel (DataStructures.Deck).
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
            UpdateView();
        }

        /// <summary>
        /// Make sure the correct card is showing.
        /// </summary>
        private void UpdateView()
        {
            if (cards.Count > 0)
            {
                var topCard = cards.Peek();
                deckView.sprite = isFaceUp ? topCard.Front : topCard.Back;
            }
            else
            {
                deckView.sprite = null;
            }
        }

        private Image deckView;

        private void Awake()
        {
            deckView = GetComponent<Image>();
        }
    }
}
