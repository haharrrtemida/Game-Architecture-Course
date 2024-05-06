using System;

namespace hw1.task4
{
    public interface IGameRule
    {
        event Action OnWinGame;
        event Action OnLoseGame;
        abstract void CheckBurstBall(Ball ball);
    }
}