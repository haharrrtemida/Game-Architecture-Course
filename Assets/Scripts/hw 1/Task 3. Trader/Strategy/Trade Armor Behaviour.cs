using UnityEngine;

public class TradeArmorBehaviour : ITraderState
{
    public void StartState()
    { 
        Debug.Log("Начал торговать бронёй");
    }

    public void UpdateState()
    {
        Debug.Log("Бронижилет – лучше для мужчины нет, покупай!");
    }

    public void StopState()
    {
        Debug.Log("Броня больше не в тренде");
    }
}