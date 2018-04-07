using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TabletopCardCompanion.Components
{
    /// <summary>
    /// This component enables the game object to be moved by clicking on the object and dragging.
    /// </summary>
    public class ClickAndDrag : MonoBehaviour
    {
        private void OnMouseDrag()
        {
            MoveToMousePosition();
        }

        /// <summary>
        /// Snap the objet to the position of the mouse.
        /// </summary>
        private void MoveToMousePosition()
        {
            var cam = FindObjectOfType<Camera>();
            var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            var deltaPos = mousePosition - transform.position;
            transform.position += deltaPos;
        }
    }
}
