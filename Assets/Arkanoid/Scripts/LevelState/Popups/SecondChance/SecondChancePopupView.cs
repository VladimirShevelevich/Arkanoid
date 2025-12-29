using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.LevelState.SecondChance
{
    public class SecondChancePopupView : MonoBehaviour
    {
        public event Action OnTryAgainClick;

        [SerializeField] private Button _tryAgainButton;

        private void Start()
        {
            _tryAgainButton.onClick.AddListener(() => OnTryAgainClick?.Invoke());
        }
    }
}