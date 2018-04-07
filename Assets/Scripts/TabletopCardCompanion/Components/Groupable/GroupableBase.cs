using UnityEngine;

namespace TabletopCardCompanion.Components.Groupable
{
    /// <summary>
    /// Base class for defining behavior when objects are placed on top of each other.
    /// <para>
    /// A group is something like a deck of playing cards, stack of terrain tiles, or bag of various items.
    /// </para>
    /// </summary>
    [RequireComponent(typeof(HeightController2D))]
    public abstract class GroupableBase : MonoBehaviour
    {
        /// <summary>
        /// Do something when an object is placed on top of this one.
        /// </summary>
        protected abstract void NotifyReceipientOfPlacement(GameObject objAbove);

        /// <summary>
        /// Notify the object below this one that this object has been placed above it.
        /// </summary>
        /// <param name="objBelow">Collider2D of the object below this one.</param>
        private void PlacedOntoObjectHandler(object sender, Collider2D objBelow)
        {
            var groupableComponent = objBelow.GetComponent<GroupableBase>();
            groupableComponent?.NotifyReceipientOfPlacement(gameObject);
        }

        private void OnEnable()
        {
            GetComponent<HeightController2D>().PlacedOntoObject += PlacedOntoObjectHandler;
        }

        private void OnDisable()
        {
            GetComponent<HeightController2D>().PlacedOntoObject -= PlacedOntoObjectHandler;
        }
    }
}
