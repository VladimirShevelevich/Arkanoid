using System;

namespace Arkanoid.Bricks
{
    public interface IBricksService
    {
        event Action OnBrickDestroyed;
    }
}