using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Bricks
{
    [CreateAssetMenu(fileName = "BricksContent", menuName = "Content/Bricks")]
    public class BricksContent : BaseContent
    {
        [field: SerializeField] public BrickView BrickPrefab { get; private set; }
        [field: SerializeField] public LayerMask BallLayer { get; set; }
    }
}