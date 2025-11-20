using System;
using VContainer.Unity;

namespace Arkanoid.DeadZone
{
    public class DeadZoneService : IInitializable, IDeadZoneService
    {
        public event Action OnDeadTriggered;
        
        private readonly DeadZoneFactory _deadZoneFactory;

        public DeadZoneService(DeadZoneFactory deadZoneFactory)
        {
            _deadZoneFactory = deadZoneFactory;
        }
        
        public void Initialize()
        {
            CreateView();
        }

        private void CreateView()
        {
            DeadZoneView view = _deadZoneFactory.Create();
            view.OnTriggered += () =>
            {
                OnDeadTriggered?.Invoke();
            };
        }
    }
}