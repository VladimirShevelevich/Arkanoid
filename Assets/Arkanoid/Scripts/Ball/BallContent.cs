using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Ball
{
    [CreateAssetMenu(fileName = "BallContent", menuName = "Content/Ball")]
    public class BallContent : BaseContent
    {
        [field: SerializeField] public GameObject BallPrefab { get; private set; } = null;
        [field: SerializeField] public float Speed { get; private set; } = 4;
        [field: SerializeField] public int MinBounceAngle { get; private set; } = 15;
        [field: SerializeField] public LayerMask PlatformLayer { get; private set; }
    }
}