using System;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces.Components.Groupable
{
    /// <summary>
    /// Base class for defining behavior when objects are placed on top of each other.
    /// <para>
    /// A group is something like a deck of playing cards, stack of terrain tiles, or bag of various items.
    /// </para>
    /// </summary>
    [RequireComponent(typeof(HeightController2D))]
    [DisallowMultipleComponent]
    public abstract class GroupableBase : MonoBehaviour
    {
        /// <summary>
        /// Do something when an object is placed on top of this one.
        /// </summary>
        protected abstract void NotifyReceipientOfPlacement(PlayingPiece objAbove);

        /// <summary>
        /// Match the position and rotation (not scale) of the above object to this one.
        /// </summary>
        protected void SnapToSelf(PlayingPiece objAbove)
        {
            // snap position
            // snap rotation
            //      note: cards should be able to be placed upside down, so snap based on shortest path for 180 degrees
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notify the object below this one that this object has been placed above it.
        /// </summary>
        /// <param name="objBelow">Collider2D of the object below this one.</param>
        private void PlacedOntoObjectHandler(object sender, Collider2D objBelow)
        {
            var playingPiece = objBelow.GetComponent<PlayingPiece>();
            var groupable    = objBelow.GetComponent<GroupableBase>();
            groupable.NotifyReceipientOfPlacement(playingPiece);
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
