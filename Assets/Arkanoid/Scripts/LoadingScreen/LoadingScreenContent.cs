using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.LoadingScreen
{
    [CreateAssetMenu(fileName = "LoadingScreenContent", menuName = "Content/LoadingScreen")]
    public class LoadingScreenContent : BaseContent
    {
        [field: SerializeField] public LoadingScreenView LoadingScreenPrefab { get; private set; }
    }
}