using System;

namespace Arkanoid.DeadZone
{
    public interface IDeadZoneService
    {
        event Action OnDeadTriggered;
    }
}