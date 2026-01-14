using System;
using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Bricks
{
    [CreateAssetMenu(fileName = "BricksContent", menuName = "Content/Bricks")]
    public class BricksContent : BaseContent
    {
        [field: SerializeField] public BrickView BrickPrefab { get; private set; }
        [field: SerializeField] public LayerMask BallLayer { get; set; }

        public Color ColorByHealth(int health)
        {
            return health switch
            {
                1 => Color.green,
                2 => Color.yellow,
                3 => Color.red,
                _ => throw new InvalidOperationException()
            };
        }

    }
}