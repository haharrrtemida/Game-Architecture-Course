class BurstOneColoredBallsRule : GameRule
{
    private BallColor _targetCollor;
    private GameManager _parent;

    public BurstOneColoredBallsRule(GameManager parent, BallColor ballColor)
    {
        _parent = parent;
        _targetCollor = ballColor;
    }

    public BallColor TargetCollor => _targetCollor;

    public override void CheckBurstBall(Ball ball)
    {
        if (ball.BallColor == TargetCollor)
        {
            int leftBalls = _parent.Spawner.GetBallsCount(TargetCollor);
            if (leftBalls == 0)
            {
                WinGame();
            }
        }
        else
        {
            LoseGame();
        }
    }
}