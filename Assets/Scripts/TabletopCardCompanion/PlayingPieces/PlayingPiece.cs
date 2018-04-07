using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.Components;
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
    [RequireComponent(typeof(HeightController2D))]
    [RequireComponent(typeof(TransformGesture))]
    [RequireComponent(typeof(Transformer))]
    public class PlayingPiece : MonoBehaviour
    {
        protected TwoSidedSprite twoSidedSprite;

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
