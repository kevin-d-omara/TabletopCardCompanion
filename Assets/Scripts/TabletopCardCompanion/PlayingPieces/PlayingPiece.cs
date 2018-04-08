using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.Components;
using TabletopCardCompanion.Components.Groupable;
using TouchScript.Behaviors;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces
{
    /// <summary>
    /// Base class for all generic playing pieces.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(TwoSidedSprite))]
    [RequireComponent(typeof(TransformGesture))]
    [RequireComponent(typeof(Transformer))]
    [RequireComponent(typeof(HeightController2D))]
    [RequireComponent(typeof(GroupableBase))]
    public class PlayingPiece : MonoBehaviour
    {
        protected TwoSidedSprite twoSidedSprite;

        [SerializeField] private MetaData metaData = new MetaData();

        /// <summary>
        /// User defined information about this playing piece.
        /// </summary>
        [Serializable]
        public class MetaData
        {
            public string name;
            public string description;
            public string componentType;
            // key-value pairs
        }

        /// <summary>
        /// Return the type of component this is. For example, an exploration tile or a blip. User defined.
        /// </summary>
        public string GetComponentType()
        {
            return metaData.componentType;
        }

        /// <summary>
        /// Flip the playing piece over so that the reverse side is showing.
        /// </summary>
        public virtual void FlipOver()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rotate the playing piece counter clockwise.
        /// </summary>
        public virtual void RotateLeft()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rotate the playing piece clockwise.
        /// </summary>
        public virtual void RotateRight()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrease the size of the playing piece.
        /// </summary>
        public virtual void ScaleDown()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Increase the size of the playing piece.
        /// </summary>
        public virtual void ScaleUp()
        {
            throw new NotImplementedException();
        }
    }
}
