using UnityEngine;

namespace Arkanoid.Borders
{
    public class BordersView : MonoBehaviour
    {
        [field: SerializeField] public Collider2D LeftBorderCollider { get; private set; }
        [field: SerializeField] public Collider2D RightBorderCollider { get; private set; }
    }
}