using UnityEngine;

namespace hw1.task3
{
    public class Trader : MonoBehaviour
    {
        public ITraderState State { get; private set; }

        private void Awake()
        {
            SetState(new NoTradeBehaviour());
        }

        public void SetState(ITraderState newState)
        {
            State?.StopState();
            State = newState;
            State.StartState();
        }
    }
}