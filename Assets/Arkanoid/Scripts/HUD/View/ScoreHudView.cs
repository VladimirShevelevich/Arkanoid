using Arkanoid.Score;
using UnityEngine;
using VContainer;

namespace Arkanoid.HUD
{
    public class ScoreHudView : MonoBehaviour
    {
        private IScoreService _scoreService;

        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }
    }
}