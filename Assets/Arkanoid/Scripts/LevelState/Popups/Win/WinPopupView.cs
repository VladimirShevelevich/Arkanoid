using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.LevelState
{
    public class WinPopupView : MonoBehaviour
    {
        public event Action OnNextLevelClick;

        [SerializeField] private Button _nextLevelButton;

        private void Start()
        {
            _nextLevelButton.onClick.AddListener(() => OnNextLevelClick?.Invoke());
        }
    }
}