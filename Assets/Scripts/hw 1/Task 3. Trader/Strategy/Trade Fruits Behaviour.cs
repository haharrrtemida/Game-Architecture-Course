using UnityEngine;

public class TradeFruitsBehaviour : ITraderState
{
    public void StartState()
    { 
        Debug.Log("Начал торговать марокканскими мандаринами");
    }

    public void UpdateState()
    {
        Debug.Log("Мандарины, сочные, спелые, вкусные, покупаем!");
    }

    public void StopState()
    {
        Debug.Log("Мандарины больше не в тренде");
    }
}