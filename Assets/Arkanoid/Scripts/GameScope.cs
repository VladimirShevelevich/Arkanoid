using Arkanoid.Level;
using VContainer;
using VContainer.Unity;

namespace Arkanoid
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<LevelCreator>();
            });
        }
    }
}