using UnityEngine;

public class TradeZoneAbstract : MonoBehaviour
{
    private BaseTrader _parentTrader;

    private void Awake()
    {
        _parentTrader = transform.parent.GetComponent<BaseTrader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _parentTrader.Trade();
    }
}