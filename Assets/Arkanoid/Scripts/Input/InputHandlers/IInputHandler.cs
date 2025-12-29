using System;
using UniRx;

namespace Arkanoid.Input
{
    public interface IInputHandler
    {
        IReadOnlyReactiveProperty<float> HorizontalInput { get; }
    }
}