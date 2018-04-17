using System;
using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.PlayingPieces.Components;
using TouchScript.Gestures;
using TouchScript.Layers;
using UnityEngine;

namespace TabletopCardCompanion
{
    /// <summary>
    /// Connector pattern. Routes requests to be magnified to the correct magnifier. Controls logic regarding when to start/stop magnifying.
    /// </summary>
    [RequireComponent(typeof(FullscreenLayer))]
    [RequireComponent(typeof(TapGesture))]
    public class MagnifierController : MonoBehaviour
    {
        /// <summary>
        /// Show an enlarged copy of the sprite. Enable the fullscreen layer so that the next touch is intercepted.
        /// </summary>
        public void Magnify(Sprite sprite)
        {
            magnifier.SetSprite(sprite);
            fullscreenLayer.enabled = true;
        }

        /// <summary>
        /// Stop showing an enlarged sprite. Disable the fullscreen layer to stop intercepting touches.
        /// </summary>
        public void StopMagnifying()
        {
            magnifier.ClearSprite();
            fullscreenLayer.enabled = false;
        }


        [SerializeField]
        private Magnifier magnifier;
        private FullscreenLayer fullscreenLayer;

        private void Awake()
        {
            fullscreenLayer = GetComponent<FullscreenLayer>();
        }

        private void OnEnable()
        {
            GetComponent<TapGesture>().Tapped += TappedHandler;

            // Subscribe to all classes that want to be magnified.
            DrawCardController.RequestMagnifyCard += RequestMagnifyHandler;
        }

        private void OnDisable()
        {
            GetComponent<TapGesture>().Tapped -= TappedHandler;

            DrawCardController.RequestMagnifyCard -= RequestMagnifyHandler;
        }

        private void TappedHandler(object sender, EventArgs e) { StopMagnifying(); }
        private void RequestMagnifyHandler(object sender, Sprite sprite) { Magnify(sprite); }
    }
}
