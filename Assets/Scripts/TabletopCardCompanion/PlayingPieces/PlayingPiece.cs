using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.PlayingPieces.Components;
using TouchScript.Behaviors;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

namespace TabletopCardCompanion.PlayingPieces
{
    /// <summary>
    /// Base class for all generic playing pieces.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(TwoSidedSprite))]
    [RequireComponent(typeof(Transformer))]
    [RequireComponent(typeof(TransformGesture))]
    [RequireComponent(typeof(TapGesture))]
    [RequireComponent(typeof(HeightController2D))]
    public abstract class PlayingPiece : MonoBehaviour
    {
        public TwoSidedSprite TwoSidedSprite { get; private set; }

        [SerializeField] private TapGesture singleTapGesture;
        [SerializeField] private TapGesture doubleTapGesture;
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
            TwoSidedSprite.FlipOver();
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

        /// <summary>
        /// Do something when an object is placed on top of this one.
        /// </summary>
        protected abstract void NotifyRecipientOfPlacement(PlayingPiece objAbove);

        /// <summary>
        /// Notify the piece below this one that this piece has been placed above it.
        /// </summary>
        /// <param name="objBelow">The playing piece underneath this one.</param>
        private void PlacedOntoObjectHandler(object sender, Collider2D objBelow)
        {
            var pieceBelow = objBelow.GetComponent<PlayingPiece>();
            pieceBelow.NotifyRecipientOfPlacement(this);
        }


        // User Input ----------------------------------------------------------

        /// <summary>
        /// When single-tapped, magnify the playing piece's image.
        /// </summary>
        private void SingleTapHandler(object sender, EventArgs e)
        {
            Debug.Log("Single tapped --> Magnify");
        }

        /// <summary>
        /// When double-tapped, pull up the right-click menu for this playing piece.
        /// </summary>
        private void DoubleTapHandler(object sender, EventArgs e)
        {
            Debug.Log("Double tapped --> Right-click control menu");
            FlipOver(); // temporary
        }

        private void OnMouseOver()
        {
            if (Input.GetButtonDown(InputAxis.FlipOver))
            {
                FlipOver();
            }
        }


        // Initialization ------------------------------------------------------

        protected virtual void Awake()
        {
            TwoSidedSprite = GetComponent<TwoSidedSprite>();
            // Must assign singleTapGesture and doubleTapGesture in editor.
        }

        private void OnEnable()
        {
            GetComponent<HeightController2D>().PlacedOntoObject += PlacedOntoObjectHandler;
            singleTapGesture.Tapped += SingleTapHandler;
            doubleTapGesture.Tapped += DoubleTapHandler;
        }

        private void OnDisable()
        {
            GetComponent<HeightController2D>().PlacedOntoObject -= PlacedOntoObjectHandler;
            singleTapGesture.Tapped -= SingleTapHandler;
            doubleTapGesture.Tapped -= DoubleTapHandler;
        }
    }
}
