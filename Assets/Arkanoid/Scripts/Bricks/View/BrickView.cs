using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace Arkanoid.Bricks
{
    public class BrickView : MonoBehaviour
    {
        public event Action OnHit;

        [SerializeField] private Collider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private BricksContent _bricksContent;

        [Inject]
        public void Construct(BricksContent bricksContent)
        {
            _bricksContent = bricksContent;
        }

        public void UpdateViewByHealth(int currentHealth)
        {
            Color color = _bricksContent.ColorByHealth(currentHealth);
            _spriteRenderer.color = color;
        }

        public void PlayDestroyVfx()
        {
            _collider.enabled = false;
            transform.DOScale(Vector3.zero, 0.1f);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (((1 << other.gameObject.layer) & _bricksContent.BallLayer) != 0)
            {
                OnBallCollision();
            }
        }

        private void OnBallCollision()
        {
            OnHit?.Invoke();
        }

    }
}