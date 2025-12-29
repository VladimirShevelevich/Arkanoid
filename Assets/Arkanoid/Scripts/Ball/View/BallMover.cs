using UnityEngine;
using VContainer;

namespace Arkanoid.Ball.View
{
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        private BallContent _ballContent;

        [Inject]
        public void Construct(BallContent ballContent)
        {
            _ballContent = ballContent;
        }

        private void Start()
        {
            StartMoving();
        }

        private void FixedUpdate()
        {
            StabilizeVelocity();
            StabilizeAngle();
        }
        
        private void OnCollisionEnter2D(Collision2D hitCollision)
        {
            if (IsPlatformLayer(hitCollision))
                ApplyPlatformHitAngle(hitCollision);
        }

        private void ApplyPlatformHitAngle(Collision2D collision)
        {
            Vector3 hitPoint = collision.GetContact(0).point;
            float paddleCenter = collision.transform.position.x;

            // difference between hit point and paddle center (-1 to +1)
            float direction = hitPoint.x - paddleCenter;

            // new direction for ball
            Vector2 newVelocity = new Vector2(direction, 1).normalized * _ballContent.Speed;
            _rb.velocity = newVelocity;
        }

        private bool IsPlatformLayer(Collision2D collision)
        {
            return ((1 << collision.gameObject.layer) & _ballContent.PlatformLayer) != 0;
        }

        /// <summary>
        /// Prevent "flat" bounces 
        /// </summary>
        private void StabilizeAngle()
        {
            Vector2 velocity = _rb.velocity;
            float angle = Vector2.Angle(velocity, Vector2.up);
            if (angle < _ballContent.MinBounceAngle || angle > 180 - _ballContent.MinBounceAngle)
            {
                velocity.x += 0.2f * Mathf.Sign(velocity.x == 0 ? 1 : velocity.x);
            }
            _rb.velocity = velocity.normalized * _ballContent.Speed;
        }

        /// <summary>
        /// Prevent speed slow
        /// </summary>
        private void StabilizeVelocity()
        {
            _rb.velocity = _rb.velocity.normalized * _ballContent.Speed;
        }

        private void StartMoving()
        {
            _rb.velocity = transform.up * _ballContent.Speed;
        }
    }
}