using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Platform
{
    [CreateAssetMenu(fileName = "PlatformContent", menuName = "Content/Platform")]
    public class PlatformContent : BaseContent
    {
        [field: SerializeField] public GameObject PlatformPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}