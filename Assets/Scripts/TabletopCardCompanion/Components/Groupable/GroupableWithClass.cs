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
        /// If the object above this one shares the same class, will combine together as a group.
        /// </summary>
        protected override void NotifyReceipientOfPlacement(GameObject objAbove)
        {
            throw new System.NotImplementedException();
        }
    }
}
