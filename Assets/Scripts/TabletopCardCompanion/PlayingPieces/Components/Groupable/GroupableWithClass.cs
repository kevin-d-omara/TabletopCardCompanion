using TabletopCardCompanion.PlayingPieces.Containers;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with other objects of the same class.
    /// <para>
    /// For example, playing cards.
    /// </para>
    /// </summary>
    public class GroupableWithClass : GroupableBase
    {
        /// <summary>
        /// Combine the above object with this one if both are the same class.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(PlayingPiece objAbove)
        {
            // TODO: move "GetComponent<PlayingPiece>().GetType();" to Awake() in base class.
            var self  = GetComponent<PlayingPiece>().GetType();
            var other = objAbove.GetType();

            if (self.IsAssignableFrom(other) || other.IsAssignableFrom(self))
            {
                Debug.Log("Both are GroupableWithClass");

                // TODO: Snap position and rotation (not scale) of 'above' to 'self'.

                var first = GetComponent<PlayingPiece>();
                Container.CreateFrom(first, objAbove);
            }
        }
    }
}
