namespace Arkanoid.LevelState.States
{
    public class SecondChanceController
    {
        public bool IsSecondChanceUsed { get; private set; }
        
        public void OnSecondChanceUsed()
        {
            IsSecondChanceUsed = true;
        }
    }
}