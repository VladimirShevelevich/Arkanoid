using Arkanoid.Content;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Level
{
    [CreateAssetMenu(fileName = "LevelsContent", menuName = "Content/Level/LevelsContent")]
    public class LevelsContent : BaseContent
    {
        [field: SerializeField] public LevelConfig[] Levels { get; private set; }
        [field: SerializeField] public LifetimeScope LevelScopePrefab { get; private set; }
    }
}