using UnityEngine;

namespace Arkanoid.LoadingScreen
{
    public class LoadingScreenFactory
    {
        private readonly LoadingScreenContent _loadingScreenContent;

        public LoadingScreenFactory(LoadingScreenContent loadingScreenContent)
        {
            _loadingScreenContent = loadingScreenContent;
        }
        
        public LoadingScreenView Create()
        {
            return Object.Instantiate(_loadingScreenContent.LoadingScreenPrefab);
        }
    }
}