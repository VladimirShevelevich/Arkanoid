using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Level
{
    [CreateAssetMenu(fileName = "LevelsContent", menuName = "Content/Level/LevelsContent")]
    public class LevelsContent : BaseContent
    {
        [field: SerializeField] public LevelConfig[] Levels { get; private set; }

    }
}