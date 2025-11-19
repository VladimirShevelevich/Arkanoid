using UnityEngine;
using VContainer;

namespace Arkanoid.Content
{
    [CreateAssetMenu(fileName = "ContentHolder", menuName = "Content/ContentHolder", order = 0)]
    public class ContentHolder : ScriptableObject
    {
        [SerializeField] private BaseContent[] _contents;
        
        public void Register(IContainerBuilder builder)
        {
            foreach (var content in _contents)
            {
                builder.RegisterInstance(content).As(content.GetType());
            }
        }
    }
}