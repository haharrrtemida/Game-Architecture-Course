using System;

public interface IGameRule
{
    event Action OnWinGame;
    event Action OnLoseGame;
    abstract void CheckBurstBall(Ball ball);
}