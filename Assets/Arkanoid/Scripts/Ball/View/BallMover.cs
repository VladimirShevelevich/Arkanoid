using System;
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

        private void OnActionInput()
        {
            if (_moving)
            {
                return;
            }
            
            Move();
        }

        private void Move()
        {
            //unparenting of the platform and applying velocity
            transform.parent = null;
            transform.rotation = Quaternion.Euler(Vector3.forward * _ballContent.InitialAngle);
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.velocity = transform.up * _ballContent.Speed;
            _moving = true;
        }
    }
}