using UnityEngine;

namespace hw1.task3
{
    public class ChangeTraderBehaviourZone : MonoBehaviour
    {
        private enum TypeZone
        {
            None,
            Fruit,
            Armor
        }

        [SerializeField] private Trader _controlledTrader;
        [SerializeField] private TypeZone _activatedTraderState;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMotor player) == false) return;
            ITraderState state = GetTraderBehaviour();
            if (state == null) throw new System.Exception("Поведение не найдено");
            _controlledTrader.SetState(state);
        }

        private ITraderState GetTraderBehaviour()
        {
            ITraderState state;
            switch (_activatedTraderState)
            {
                case TypeZone.None:
                    state = new NoTradeBehaviour();
                    break;
                case TypeZone.Fruit:
                    state = new TradeFruitsBehaviour();
                    break;
                case TypeZone.Armor:
                    state = new TradeArmorBehaviour();
                    break;
                default:
                    state = null;
                    break;
            }
            return state;
        }
    }
}