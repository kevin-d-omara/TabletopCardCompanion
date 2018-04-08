using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with other objects of this same class.
    /// <para>
    /// For example, playing cards.
    /// </para>
    /// </summary>
    public class GroupableWithSelf : GroupableBase
    {
        /// <summary>
        /// Combine the above object with this one if both are <see cref="GroupableWithSelf"/>.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            var groupableWithSelf = objAbove.GetComponent<GroupableWithSelf>();

            if (groupableWithSelf)
            {
                // Combine together to create a stack or deck.
                Debug.Log("Both are GroupableWithSelf");
            }
        }
    }
}
