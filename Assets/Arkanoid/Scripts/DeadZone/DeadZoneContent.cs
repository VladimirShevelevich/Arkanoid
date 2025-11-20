using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.DeadZone
{
    [CreateAssetMenu(fileName = "DeadZoneContent", menuName = "Content/DeadZone")]
    public class DeadZoneContent : BaseContent
    {
        [field: SerializeField] public DeadZoneView DeadZonePrefab { get; private set; }
        [field: SerializeField] public LayerMask CollisionLayer { get; private set; }
    }
}