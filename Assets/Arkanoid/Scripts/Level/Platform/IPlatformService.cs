using Arkanoid.Tools.Initialization;
using UnityEngine;

namespace Arkanoid.Platform
{
    public interface IPlatformService : IAsyncInitializable
    {
        public Transform PlatformTransform { get; }
    }
}