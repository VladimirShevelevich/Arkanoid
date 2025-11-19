using Arkanoid.Input;
using UnityEngine;
using VContainer;

namespace Arkanoid.Platform
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        private PlatformContent _platformContent;
        private IInputService _inputService;

        [Inject]
        public void Construct(PlatformContent platformContent, IInputService inputService)
        {
            _platformContent = platformContent;
            _inputService = inputService;
        }
        
        private float CurrentInput => _inputService.HorizontalInput.Value;
        
        void FixedUpdate()
        {
            ApplyVelocity();
        }

        private void ApplyVelocity()
        {
            var move = CurrentInput * _platformContent.Speed;
            _rb.velocity = new Vector2(move, _rb.velocity.y);
        }
    }
}