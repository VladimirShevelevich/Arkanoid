using UnityEngine;

namespace Arkanoid.Platform
{
    public class PlatformFactory
    {
        private readonly PlatformContent _platformContent;

        public PlatformFactory(PlatformContent platformContent)
        {
            _platformContent = platformContent;
        }
        
        public void Create()
        {
            Object.Instantiate(_platformContent.PlatformPrefab);
        }
    }
}