using Arkanoid.Input;
using Arkanoid.LevelState;
using UnityEngine;
using VContainer;

namespace Arkanoid.Platform
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        private PlatformContent _platformContent;
        private IInputService _inputService;
        private ILevelStateService _levelStateService;

        [Inject]
        public void Construct(PlatformContent platformContent, IInputService inputService, ILevelStateService levelStateService)
        {
            _platformContent = platformContent;
            _inputService = inputService;
            _levelStateService = levelStateService;
        }
        
        private float CurrentInput => _inputService.HorizontalInput.Value;
        
        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float move = _levelStateService.CurrentState.Value == LevelStateType.GamePlay ? 
                CurrentInput * _platformContent.Speed : 
                0;
            
            _rb.velocity = new Vector2(move, _rb.velocity.y);
        }
    }
}