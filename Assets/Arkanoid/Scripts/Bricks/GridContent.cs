using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Bricks
{
    [CreateAssetMenu(fileName = "GridContent", menuName = "Content/Grid")]
    public class GridContent : BaseContent
    {
        [field: SerializeField] public int GridRows { get; private set; } = 6;
        [field: SerializeField] public int GridColumns { get; private set; } = 10;
        [field: SerializeField] public float GridHorizontalSpace  { get; private set; } = 0.1f;
        [field: SerializeField] public float GridVerticalSpace  { get; private set; } = 0.1f;
        [field: SerializeField] public Vector2 GridStartPosition  { get; private set; }
    }
}