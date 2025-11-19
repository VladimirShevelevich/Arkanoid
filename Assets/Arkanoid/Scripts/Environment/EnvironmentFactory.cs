using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Environment
{
    public class EnvironmentFactory : IInitializable
    {
        private readonly EnvironmentContent _content;

        public EnvironmentFactory(EnvironmentContent content)
        {
            _content = content;
        }

        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            Object.Instantiate(_content.EnvironmentPrefab);
        }
    }
}