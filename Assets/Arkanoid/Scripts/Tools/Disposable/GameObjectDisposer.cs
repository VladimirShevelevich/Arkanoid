using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Arkanoid.Tools.Disposable
{
    public class GameObjectDisposer : IDisposable
    {
        private GameObject _gameObject;

        public GameObjectDisposer(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void Dispose()
        {
            if (_gameObject != null)
            {
                Object.Destroy(_gameObject);
                _gameObject = null;
            }
        }
    }
}