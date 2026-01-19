using UniRx;

namespace Arkanoid.Score
{
    public interface IScoreService
    {
        public void AddScore(int score);
        public IReadOnlyReactiveProperty<int> CurrentScore { get; }
    }
}