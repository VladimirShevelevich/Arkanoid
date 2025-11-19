using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Ball
{
    [CreateAssetMenu(fileName = "BallContent", menuName = "Content/Ball")]
    public class BallContent : BaseContent
    {
        [field: SerializeField] public GameObject BallPrefab { get; private set; } = null;
        [field: SerializeField] public float Speed { get; private set; } = 4;
        [field: SerializeField] public float InitialAngle { get; private set; } = 45;
    }
}