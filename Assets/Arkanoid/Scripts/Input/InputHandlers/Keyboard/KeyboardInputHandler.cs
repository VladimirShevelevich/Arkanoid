using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Input
{
    public class KeyboardInputHandler : IInputHandler, ITickable
    {
        public IReadOnlyReactiveProperty<float> HorizontalInput => _horizontalInput;
        private readonly ReactiveProperty<float> _horizontalInput = new();
        
        public event Action OnActionInput;

        public void Tick()
        {
            UpdateAxeInput();
            CheckActionInput();
        }

        private void UpdateAxeInput()
        {
            _horizontalInput.Value = UnityEngine.Input.GetAxisRaw("Horizontal");
        }

        private void CheckActionInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                OnActionInput?.Invoke();
            }
        }
    }
}