using UnityEngine;

namespace Arkanoid.Platform
{
    public interface IPlatformService
    {
        public Transform PlatformTransform { get; }
    }
}