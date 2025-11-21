using Arkanoid.Input;
using UnityEngine;
using VContainer;

namespace Arkanoid.Ball.View
{
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        private BallContent _ballContent;
        private IInputService _inputService;
        private bool _moving;

        [Inject]
        public void Construct(BallContent ballContent, IInputService inputService)
        {
            _ballContent = ballContent;
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.OnActionInput += OnActionInput;
        }

        private void OnDestroy()
        {
            _inputService.OnActionInput -= OnActionInput;
        }

        private void FixedUpdate()
        {
            if (_moving)
            {
                StabilizeVelocity();
                StabilizeAngle();
            }
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

        private void OnActionInput()
        {
            if (_moving)
            {
                return;
            }
            
            StartMoving();
        }

        private void StartMoving()
        {
            //unparenting from the platform and applying velocity
            transform.parent = null;
            transform.rotation = Quaternion.Euler(Vector3.forward * _ballContent.InitialAngle);
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.velocity = transform.up * _ballContent.Speed;
            _moving = true;
        }
    }
}