using VContainer;

namespace Arkanoid.Popups
{
    public static class PopupsInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<PopupsService>(Lifetime.Singleton);
        }
    }
}