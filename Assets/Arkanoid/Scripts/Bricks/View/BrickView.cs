using System;
using UnityEngine;
using VContainer;

namespace Arkanoid.Bricks
{
    public class BrickView : MonoBehaviour
    {
        public event Action OnHit;
        
        private BricksContent _bricksContent;

        [Inject]
        public void Construct(BricksContent bricksContent)
        {
            _bricksContent = bricksContent;
        }

        public void UpdateViewByHealth(int currentHealth)
        {
            
        }

        public void PlayDestroyVfx()
        {
            
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