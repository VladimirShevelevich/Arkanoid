using VContainer.Unity;

namespace Arkanoid.Platform
{
    public class PlatformService : IInitializable
    {
        private readonly PlatformFactory _platformFactory;

        public PlatformService(PlatformFactory platformFactory)
        {
            _platformFactory = platformFactory;
        }
        
        public void Initialize()
        {
            _platformFactory.Create();
        }
    }
}