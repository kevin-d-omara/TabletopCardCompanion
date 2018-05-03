using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TabletopCardCompanion.Models
{
    /// <summary>
    /// An immutable list of cards for a deck.
    /// </summary>
    public class DeckListModel
    {
        public ReadOnlyCollection<CardModel> Cards { get; }

        public DeckListModel(IList<CardModel> cards)
        {
            Cards = new ReadOnlyCollection<CardModel>(cards);
        }
    }
}
