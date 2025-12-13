using Arkanoid.Tools;
using UniRx;

namespace Arkanoid.Score
{
    public class ScoreService : IScoreService
    {
        public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;
        private readonly ReactiveProperty<int> _currentScore = new();

        public void AddScore(int score)
        {
            _currentScore.Value += score;
            CustomLogger.DebugLog($"Score: {_currentScore.Value}");
        }
    }
}