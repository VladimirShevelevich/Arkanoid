using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Ball
{
    [CreateAssetMenu(fileName = "BallContent", menuName = "Content/Ball")]
    public class BallContent : BaseContent
    {
        [field: SerializeField] public GameObject BallPrefab { get; private set; }
    }
}