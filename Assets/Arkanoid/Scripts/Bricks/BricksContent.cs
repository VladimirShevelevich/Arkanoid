using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Bricks
{
    [CreateAssetMenu(fileName = "BricksContent", menuName = "Content/Bricks")]
    public class BricksContent : BaseContent
    {
        [field: SerializeField] public GameObject BrickPrefab { get; private set; }
    }
}