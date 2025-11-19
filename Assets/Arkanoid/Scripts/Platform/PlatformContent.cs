using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Platform
{
    [CreateAssetMenu(fileName = "PlatformContent", menuName = "Content/Platform")]
    public class PlatformContent : BaseContent
    {
        [field: SerializeField] public PlatformView PlatformPrefab;
    }
}