using UniRx;

namespace Arkanoid.Score
{
    public class ScoreService : IScoreService
    {
        public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;
        private readonly ReactiveProperty<int> _currentScore = new();

        public void AddScore(int score)
        {
            throw new System.NotImplementedException();
        }
    }
}