using UnityEngine;

namespace TabletopCardCompanion.Components.Groupable
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
        /// Combine the above object with this one if both are are the same class of object.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            throw new System.NotImplementedException();
        }
    }
}
