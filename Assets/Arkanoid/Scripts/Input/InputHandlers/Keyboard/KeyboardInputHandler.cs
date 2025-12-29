using UniRx;
using VContainer.Unity;

namespace Arkanoid.Input
{
    public class KeyboardInputHandler : IInputHandler, ITickable
    {
        public IReadOnlyReactiveProperty<float> HorizontalInput => _horizontalInput;
        private readonly ReactiveProperty<float> _horizontalInput = new();

        public void Tick()
        {
            UpdateAxeInput();
        }

        private void UpdateAxeInput()
        {
            _horizontalInput.Value = UnityEngine.Input.GetAxisRaw("Horizontal");
        }
    }
}