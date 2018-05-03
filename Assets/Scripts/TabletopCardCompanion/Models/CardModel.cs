using UnityEngine;

namespace TabletopCardCompanion.Models
{
    /// <summary>
    /// An immutable collection of data for a playing card.
    /// </summary>
    public class CardModel
    {
        public Sprite Front { get; }
        public Sprite Back { get; }

        public CardModel(Sprite front, Sprite back)
        {
            Front = front;
            Back = back;
        }
    }
}
