using UnityEngine;

namespace TabletopCardCompanion.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with copies of itself.
    /// <para>
    /// For example, poker chips of the same denomination.
    /// </para>
    /// </summary>
    public class GroupableWithCopy : GroupableBase
    {
        /// <summary>
        ///  Combine the above object with this one if both are copies of each other.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            // TODO: add PlayingPiece.GetOriginal
            // TODO: add PlayingPiece.Initialize
            // TODO: add PlayingPiece.Clone

            throw new System.NotImplementedException();
        }
    }
}
