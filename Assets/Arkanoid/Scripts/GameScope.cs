using Arkanoid.Content;
using Arkanoid.Input;
using Arkanoid.Level;
using Arkanoid.Popups;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ContentHolder _contentHolder;
        [SerializeField] private Canvas _mainCanvas;
        
        protected override void Configure(IContainerBuilder builder)
        {
            _contentHolder.Register(builder);
            builder.RegisterInstance(_mainCanvas);
            
            InputInstaller.Install(builder);
            LevelCreatorInstaller.Install(builder);
        }
    }
}