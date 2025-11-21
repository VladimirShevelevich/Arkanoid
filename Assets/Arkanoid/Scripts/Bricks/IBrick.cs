using System;

namespace Arkanoid.Bricks
{
    public interface IBrick : IDisposable
    {
        event Action OnDestroyed;
    }
}