using Arkanoid.Tools.Disposable;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Environment
{
    public class EnvironmentFactory : BaseDisposable, IInitializable
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
            var go = Object.Instantiate(_content.EnvironmentPrefab);
            AddDisposable(new GameObjectDisposer(go));
        }
    }
}