using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.LevelState
{
    public class GameOverPopupView : MonoBehaviour
    {
        public event Action OnRestartClick;

        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(() => OnRestartClick?.Invoke());
        }
    }
}