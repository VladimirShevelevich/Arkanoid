using Arkanoid.Borders;
using Arkanoid.Input;
using Arkanoid.LevelState;
using UnityEngine;
using VContainer;

namespace Arkanoid.Platform
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Collider2D _collider;
        
        private PlatformContent _platformContent;
        private IInputService _inputService;
        private ILevelStateService _levelStateService;
        private IBordersService _bordersService;
        
        private float _minX;
        private float _maxX;

        [Inject]
        public void Construct(PlatformContent platformContent,
            IInputService inputService, 
            ILevelStateService levelStateService,
            IBordersService bordersService)
        {
            _platformContent = platformContent;
            _inputService = inputService;
            _levelStateService = levelStateService;
            _bordersService = bordersService;
        }
        
        private float CurrentInput => _inputService.HorizontalInput.Value;

        private void Start()
        {
            SetMovingBoundaries();
        }

        private void SetMovingBoundaries()
        {
            float halfWidth = GetComponent<Collider2D>().bounds.extents.x;

            float left = _bordersService.LeftBorderBounds.max.x;
            float right = _bordersService.RightBorderBounds.min.x;

            _minX = left + halfWidth;
            _maxX = right - halfWidth;
        }

        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float move = CurrentInput * _platformContent.Speed * Time.fixedDeltaTime;
            Vector2 newPos = _rb.position + new Vector2(move, 0);
            newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);

            _rb.MovePosition(newPos);
        }
    }
}