using UnityEngine;

namespace TabletopCardCompanion.Components.Groupable
{
    /// <summary>
    /// This object may only be grouped with copies of itself.
    /// <para>
    /// For example, poker chips of the same denomination.
    /// </para>
    /// </summary>
    public class GroupableWithSelf : GroupableBase
    {
        /// <summary>
        /// If the object above this one is an identical copy, will combine together as a group.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            throw new System.NotImplementedException();
        }
    }
}
