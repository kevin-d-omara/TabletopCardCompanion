using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// This object may not be grouped with other objects.
    /// </summary>
    public class GroupableWithNone : GroupableBase
    {
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            // do nothing
        }
    }
}
