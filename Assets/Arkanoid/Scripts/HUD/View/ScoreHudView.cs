using Arkanoid.Score;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

namespace Arkanoid.HUD
{
    public class ScoreHudView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        
        private IScoreService _scoreService;

        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Start()
        {
            _scoreService.CurrentScore.Subscribe(UpdateScore).
                AddTo(this);
        }

        private void UpdateScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}