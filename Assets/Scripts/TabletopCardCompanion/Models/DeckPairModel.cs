using TabletopCardCompanion.DataStructures;

namespace TabletopCardCompanion.Models
{
    /// <summary>
    /// An immutable bundle of two decks: the draw and discard piles.
    /// </summary>
    public class DeckPairModel
    {
        public Deck<CardModel> DrawPile { get; }
        public Deck<CardModel> DiscardPile { get; }

        public DeckPairModel(Deck<CardModel> drawPile, Deck<CardModel> discardPile)
        {
            DrawPile = drawPile;
            DiscardPile = discardPile;
        }
    }
}
