using UnityEngine;

namespace Arkanoid.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "Content/Level/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        /// <summary>
        /// column amd raw index of the brick
        /// </summary>
        [field: SerializeField] public Vector2Int[] BricksGridPositions { get; private set; }
    }
}