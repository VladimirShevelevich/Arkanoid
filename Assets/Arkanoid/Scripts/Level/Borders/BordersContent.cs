using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Borders
{
    [CreateAssetMenu(fileName = "BordersContent", menuName = "Content/Borders")]
    public class BordersContent : BaseContent
    {
        [field: SerializeField] public BordersView BordersPrefab { get; private set; }
    }
}