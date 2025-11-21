using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.LevelState
{
    [CreateAssetMenu(fileName = "LevelStateContent", menuName = "Content/LevelState")]
    public class LevelStateContent : BaseContent
    {
        [field: SerializeField] public GameOverPopupView GameOverPopupPrefab { get; private set; }
    }
}