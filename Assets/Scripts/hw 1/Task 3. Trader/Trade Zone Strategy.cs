using UnityEngine;

namespace hw1.task3
{
    public class TradeZoneStrategy : MonoBehaviour
    {
        private Trader _parentTrader;

        private void Awake()
        {
            _parentTrader = transform.parent.GetComponent<Trader>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _parentTrader.State.UpdateState();
        }
    }
}