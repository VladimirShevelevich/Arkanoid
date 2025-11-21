using System;

namespace Arkanoid.Bricks
{
    public interface IBrick
    {
        event Action OnDestroyed;
    }
}