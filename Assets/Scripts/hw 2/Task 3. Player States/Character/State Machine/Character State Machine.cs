using System.Collections.Generic;
using System.Linq;

namespace hw2.task3
{    
    class CharacterStateMachine : IStateSwitcher
    {
        private List<IPlayerState> _states;
        private IPlayerState _currentState;

        public CharacterStateMachine(Character character)
        {
            StateMachineData data = new StateMachineData();
            _states = new List<IPlayerState>()
            {
                new IdlingState(this, data, character),
                new WalkingState(this, data, character),
                new RunningState(this, data, character),
                new SprintingState(this, data, character),
                new JumpingState(this, data, character),
                new FallingState(this, data, character)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IPlayerState state = _states.FirstOrDefault(state => state is T);
            
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void HandleInput() => _currentState.HandleInput();

        public void Update() => _currentState.Update();
    }
}