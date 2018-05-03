using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TabletopCardCompanion.Models
{
    /// <summary>
    /// An immutable collection of decks belonging to a single screen of the in-game view.
    /// </summary>
    public class TabModel
    {
        public ReadOnlyCollection<DeckPairModel> Decks { get; }

        public TabModel(IList<DeckPairModel> decks)
        {
            Decks = new ReadOnlyCollection<DeckPairModel>(decks);
        }
    }
}
