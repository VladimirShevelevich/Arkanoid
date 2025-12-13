using VContainer;

namespace Arkanoid.Score
{
    public static class ScoreInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<ScoreService>(Lifetime.Scoped);
        }
    }
}