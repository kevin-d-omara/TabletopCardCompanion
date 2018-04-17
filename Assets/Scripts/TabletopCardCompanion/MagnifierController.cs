using System.Collections;
using System.Collections.Generic;
using TabletopCardCompanion.PlayingPieces.Components;
using UnityEngine;

namespace TabletopCardCompanion
{
    /// <summary>
    /// Connector pattern. Routes requests to be magnified to the correct magnifier. Controls logic regarding when to start/stop magnifying.
    /// </summary>
    public class MagnifierController : MonoBehaviour
    {
        /// <summary>
        /// Magnify the sprite that has requested to be enlarged.
        /// </summary>
        private void RequestMagnifyHandler(object sender, Sprite sprite)
        {
            magnifier.SetSprite(sprite);
        }

        // TODO: After setting sprite, catch next tap. On that tap, clear the magnified sprite.

        [SerializeField] private Magnifier magnifier;

        private void OnEnable()
        {
            // TODO: Find a less coupled / omniscient way of doing this.
            // Subscribe to all classes that want to be magnified.
            DrawCardController.RequestMagnifyCard += RequestMagnifyHandler;
        }

        private void OnDisable()
        {
            DrawCardController.RequestMagnifyCard -= RequestMagnifyHandler;
        }
    }
}
