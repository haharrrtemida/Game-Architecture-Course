class BurstAllBallsRule : GameRule
{
    private GameManager _parent;
    
    public BurstAllBallsRule(GameManager parent)
    {
        _parent = parent;
    }

    public override void CheckBurstBall(Ball ball)
    {
        int leftBalls = _parent.Spawner.BallsCollection.Count;
        if (leftBalls == 0)
        {
            WinGame();
        }
    }
}