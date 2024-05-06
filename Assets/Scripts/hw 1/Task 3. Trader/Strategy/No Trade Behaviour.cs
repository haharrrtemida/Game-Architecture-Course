using UnityEngine;

namespace hw1.task3
{
    public class NoTradeBehaviour : ITraderState
    {
        public void StartState()
        { 
            Debug.Log("Лавка прикрыта, пока не торгуем!");
        }

        public void UpdateState()
        {
            Debug.Log("Пока нет товаров, друг, мне нечего тебе предложить");
        }

        public void StopState()
        {
            Debug.Log("Кажется, прибыл новый товар");
        }
    }
}