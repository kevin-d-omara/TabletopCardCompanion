using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

namespace TabletopCardCompanion
{
    /// <summary>
    /// Simulates the third dimension (in/out of the screen) for a 2d top-down game.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]       // Required for BoxCasting to find objects below this one.
    [RequireComponent(typeof(TransformGesture))]    // Source of pick up and set down signals.
    public class HeightController2D : MonoBehaviour
    {
        /// <summary>
        /// Height objects are raised to when lifted. This should be just below the camera (default camera height = -10f).
        /// </summary>
        private static readonly float LIFT_HEIGHT = 9f;

        /// <summary>
        /// Distance between objects on top of each other. Used to make sprites drawn in the correct order.
        /// </summary>
        private static readonly float HEIGHT_BUFFER = 0.001f;

        private BoxCollider2D boxCollider;
        private TransformGesture transformGesture;

        /// <summary>
        /// Raise the object so that it is drawn on top of all other sprites.
        /// </summary>
        private void RaiseObject()
        {
            var p = transform.position;
            transform.position = new Vector3(p.x, p.y, -LIFT_HEIGHT);
        }

        /// <summary>
        /// Lower the object down. If it lands on another object, it will be placed above it.
        /// </summary>
        private void LowerObject()
        {
            var objectBelow = Physics2D.OverlapBox(transform.position, boxCollider.size / 2f, angle: 0f,
                layerMask: Physics2D.DefaultRaycastLayers,
                minDepth: transform.position.z + HEIGHT_BUFFER / 2);

            float height;
            if (objectBelow != null)
            {
                height = objectBelow.transform.position.z - HEIGHT_BUFFER;
            }
            else
            {
                height = 0f;
            }

            var p = transform.position;
            transform.position = new Vector3(p.x, p.y, height);
        }

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            transformGesture = GetComponent<TransformGesture>();
        }

        private void OnEnable()
        {
            transformGesture.TransformStarted   += StartToRaise;
            transformGesture.TransformCompleted += StartToLower;
        }

        private void OnDisable()
        {
            transformGesture.TransformStarted   -= StartToRaise;
            transformGesture.TransformCompleted -= StartToLower;
        }

        private void StartToRaise(object sender, EventArgs e) { RaiseObject(); }
        private void StartToLower(object sender, EventArgs e) { LowerObject(); }
    }
}
