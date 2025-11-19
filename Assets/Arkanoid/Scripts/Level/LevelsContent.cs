using UnityEngine;

namespace Arkanoid.Level
{
    [CreateAssetMenu(fileName = "LevelsContent", menuName = "Content/Levels")]
    public class LevelsContent : ScriptableObject
    {
        [field: SerializeField] public LevelScope[] Levels { get; private set; }

    }
}