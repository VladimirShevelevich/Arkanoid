using System;
using UniRx;

namespace Arkanoid.Input
{
    public interface IInputService
    {
        IReadOnlyReactiveProperty<float> HorizontalInput { get; }
    }
}