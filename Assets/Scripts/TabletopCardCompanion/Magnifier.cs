using UnityEngine;
using UnityEngine.UI;

namespace TabletopCardCompanion
{
    /// <summary>
    /// UI element that presents an enlarged sprite for easier viewing.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class Magnifier : MonoBehaviour
    {
        /// <summary>
        /// Set which sprite is magnified.
        /// </summary>
        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
            image.color = Color.white;
        }

        /// <summary>
        /// Clear the currently magnified sprite.
        /// </summary>
        public void ClearSprite()
        {
            image.sprite = null;
            image.color = Color.clear;
        }


        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }
    }
}
