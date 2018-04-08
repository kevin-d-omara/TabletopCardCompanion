using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with other objects of the same component type.
    /// <para>
    /// For example, hex tiles in Settlers of Catan.
    /// </para>
    /// </summary>
    public class GroupableWithComponent : GroupableBase
    {
        /// <summary>
        /// Combine the above object with this one if both are of the same component type.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            var self  =          GetComponent<PlayingPiece>().GetComponentType();
            var other = objAbove.GetComponent<PlayingPiece>().GetComponentType();

            if (!string.IsNullOrWhiteSpace(self) && !string.IsNullOrWhiteSpace(other) &&
                string.Equals(self, other))
            {
                Debug.Log("Both are GroupableWithComponent");
            }
        }
    }
}
