using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TabletopCardCompanion.Components
{
    /// <summary>
    /// This component represents a double-sided sprite. It could be used for playing cards, boardgame tiles, etc.
    /// <para>
    /// If a BoxCollider2D is attached, it is automatically resized to fit the currently showing Sprite.
    /// </para>
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    [DisallowMultipleComponent]
    public class TwoSidedSprite : MonoBehaviour
    {
        [SerializeField] private Sprite front;
        [SerializeField] private Sprite back;
        [SerializeField] private bool isShowingFront = true;

        private BoxCollider2D boxCollider;
        private SpriteRenderer spriteRenderer;

        public void FlipOver()
        {
            isShowingFront = !isShowingFront;
            UpdateView();
        }

        public void SetFront(Sprite sprite)
        {
            front = sprite;
            UpdateView();
        }

        public void SetBack(Sprite sprite)
        {
            back = sprite;
            UpdateView();
        }

        /// <summary>
        /// Display the correct Sprite (front or back) and resize the box collider to fit the sprite.
        /// </summary>
        private void UpdateView()
        {
            spriteRenderer.sprite = isShowingFront ? front : back;

            if (boxCollider != null)
            {
                boxCollider.size = spriteRenderer.sprite.bounds.size;
            }
        }

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnValidate()
        {
            if (front == null || back == null)
                return;

            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();
            UpdateView();
        }
    }
}
