using System;
using System.Collections.Generic;
using UniRx;
using VContainer.Unity;

namespace Arkanoid.Input
{
    public class InputService : IInputService, IInitializable
    {
        public IReadOnlyReactiveProperty<float> HorizontalInput => _horizontalInput;
        private readonly ReactiveProperty<float> _horizontalInput = new();
        public event Action OnActionInput;
        
        private readonly IEnumerable<IInputHandler> _inputHandlers;

        public InputService(IEnumerable<IInputHandler> inputHandlers)
        {
            _inputHandlers = inputHandlers;
        }
        
        public void Initialize()
        {
            SubscribeOnHandlers();
        }

        private void SubscribeOnHandlers()
        {
            foreach (var inputHandler in _inputHandlers)
            {
                inputHandler.HorizontalInput.Subscribe(input => 
                    _horizontalInput.Value = input);

                inputHandler.OnActionInput += 
                    () => OnActionInput?.Invoke();
            }
        }
    }
}