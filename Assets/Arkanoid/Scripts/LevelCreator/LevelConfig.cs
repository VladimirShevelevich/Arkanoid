using System;
using UnityEngine;

namespace Arkanoid.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "Content/Level/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public BrickInfo[] Bricks { get; private set; }
        
        [Serializable]
        public struct BrickInfo
        {
            /// <summary>
            /// column amd raw index of the brick
            /// </summary>
            public Vector2Int GridPosition;
            public int Health;
        }
    }
}