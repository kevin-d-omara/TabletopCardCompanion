using UnityEngine;
using UnityEngine.UI;

namespace TabletopCardCompanion.Views
{
    /// <summary>
    /// UI element that presents an enlarged sprite for easier viewing.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class MagnifierView : MonoBehaviour
    {
        /// <summary>
        /// Show a magnified sprite.
        /// </summary>
        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
            image.color = Color.white;
        }

        /// <summary>
        /// Stop showing a magnified sprite.
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
