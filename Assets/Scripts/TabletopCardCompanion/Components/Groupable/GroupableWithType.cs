using UnityEngine;

namespace TabletopCardCompanion.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with other objects of the same type.
    /// <para>
    /// For example, hex tiles in Settlers of Catan.
    /// </para>
    /// </summary>
    public class GroupableWithType : GroupableBase
    {
        /// <summary>
        /// If the object above this one belongs to the same type, will combine together as a group.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            throw new System.NotImplementedException();
        }
    }
}
