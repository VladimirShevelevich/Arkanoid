using Arkanoid.Content;
using Arkanoid.Input;
using Arkanoid.Level;
using Arkanoid.LoadingScreen;
using Arkanoid.Popups;
using Arkanoid.Sound;
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

            LoadingScreenInstaller.Install(builder);
            InputInstaller.Install(builder);
            SoundInstaller.Install(builder);
            PopupsInstaller.Install(builder);
            LevelCreatorInstaller.Install(builder);
        }
    }
}