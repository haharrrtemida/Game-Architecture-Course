using System.Collections.Generic;
using System.Linq;

namespace hw2.task2.NPC
{
    public class WorkerStateMachine : IStateSwitcher
    {
        private List<INPCState> _states;
        private INPCState _currentState;

        public WorkerStateMachine(WorkerNPC worker)
        {
            StateMachineData data = new StateMachineData();
            _states = new List<INPCState>()
            {
                new RestingState(this, data, worker),
                new WalkingState(this, data, worker),
                new MiningState(this, data, worker)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            INPCState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();

    }
}