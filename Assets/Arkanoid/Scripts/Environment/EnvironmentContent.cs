using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Environment
{
    [CreateAssetMenu(fileName = "EnvironmentContent", menuName = "Content/Environment")]
    public class EnvironmentContent : BaseContent
    {
        [field: SerializeField] public GameObject EnvironmentPrefab { get; private set; }
    }
}