using Arkanoid.Content;
using Arkanoid.LevelState.SecondChance;
using UnityEngine;

namespace Arkanoid.LevelState
{
    [CreateAssetMenu(fileName = "LevelStateContent", menuName = "Content/LevelState")]
    public class LevelStateContent : BaseContent
    {
        [field: SerializeField] public GameOverPopupView GameOverPopupPrefab { get; private set; }
        [field: SerializeField] public WinPopupView WinPopupPrefab { get; private set; }
        [field: SerializeField] public SecondChancePopupView SecondChancePopupPrefab { get; private set; }
        [field: SerializeField] public AudioClip GameOverSound { get; private set; }
        [field: SerializeField] public AudioClip WinSound { get; private set; }
    }
}