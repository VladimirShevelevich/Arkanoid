using UnityEngine;

namespace Arkanoid.Borders
{
    public interface IBordersService
    {
        Bounds LeftBorderBounds { get; }
        Bounds RightBorderBounds { get; }
    }
}