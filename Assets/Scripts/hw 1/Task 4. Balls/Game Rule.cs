using System;
using UnityEngine;

namespace hw1.task4
{
    public abstract class GameRule : IGameRule
    {
        public event Action OnWinGame;
        public event Action OnLoseGame;

        public abstract void CheckBurstBall(Ball ball);

        protected virtual void WinGame()
        {
            Debug.Log("Вы победили!");
            OnWinGame?.Invoke();
        }

        protected virtual void LoseGame()
        {
            Debug.Log("Вы проиграли!");
            OnLoseGame?.Invoke();
        }
    }
}