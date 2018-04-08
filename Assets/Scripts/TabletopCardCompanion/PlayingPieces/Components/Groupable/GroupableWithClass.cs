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
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            // TODO: not safe if self or other don't have PlayingPiece components attached.
            var self  =          GetComponent<PlayingPiece>().GetType();
            var other = objAbove.GetComponent<PlayingPiece>().GetType();

            if (self.IsAssignableFrom(other) || other.IsAssignableFrom(self))
            {
                Debug.Log("Both are GroupableWithClass");
            }
        }
    }
}
