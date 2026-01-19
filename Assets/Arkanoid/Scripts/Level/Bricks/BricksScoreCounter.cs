using System;
using Arkanoid.Level;
using Arkanoid.Score;
using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public class BricksScoreCounter : IInitializable, IDisposable
    {
        private readonly IBricksService _bricksService;
        private readonly IScoreService _scoreService;

        public BricksScoreCounter(IBricksService bricksService, IScoreService scoreService)
        {
            _bricksService = bricksService;
            _scoreService = scoreService;
        }
        
        public void Initialize()
        {
            _bricksService.OnBrickDestroyed += OnBrickDestroyed;
        }

        private void OnBrickDestroyed(LevelConfig.BrickInfo brickInfo)
        {
            AddScore(brickInfo.ScoreReward);
        }

        private void AddScore(int score)
        {
            _scoreService.AddScore(score);
        }

        public void Dispose()
        {
            _bricksService.OnBrickDestroyed -= OnBrickDestroyed;
        }
    }
}