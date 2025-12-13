using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.HUD
{
    [CreateAssetMenu(fileName = "HudContent", menuName = "Content/HUD")]
    public class HudContent : BaseContent
    {
        [field: SerializeField] public GameObject HudPrefab { get; private set; }
    }
}