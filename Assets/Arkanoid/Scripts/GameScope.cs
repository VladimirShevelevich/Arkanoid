using Arkanoid.Content;
using Arkanoid.Input;
using Arkanoid.Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ContentHolder _contentHolder;
        
        protected override void Configure(IContainerBuilder builder)
        {
            _contentHolder.Register(builder);
            InputInstaller.Install(builder);
            LevelCreatorInstaller.Install(builder);
        }
    }
}