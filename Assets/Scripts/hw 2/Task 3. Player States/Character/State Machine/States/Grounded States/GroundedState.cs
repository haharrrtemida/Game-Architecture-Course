using UnityEngine.InputSystem;

namespace hw2.task3.PlayerState
{
    public class GroundedState : MovementState
    {
        private readonly GroundChecker _groundChecker;
        
        public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _groundChecker = character.GroundChecker;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartGrounded();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopGrounded();
        }

        public override void Update()
        {
            base.Update();

            if (_groundChecker.IsTouches) return;
            
            StateSwitcher.SwitchState<FallingState>();
        }

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();
            Input.Movement.Jump.started += OnJumpKeyPressed;
            Input.Movement.Walk.started += OnWalkKeyPressed;
            Input.Movement.Walk.canceled += OnWalkKeyReleased;
            Input.Movement.Sprint.started += OnSprintKeyPressed;
            Input.Movement.Sprint.canceled += OnSprintKeyReleased;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();
            
            Input.Movement.Jump.started -= OnJumpKeyPressed;
            Input.Movement.Walk.started -= OnWalkKeyPressed;
            Input.Movement.Walk.canceled -= OnWalkKeyReleased;
            Input.Movement.Sprint.started -= OnSprintKeyPressed;
            Input.Movement.Sprint.canceled -= OnSprintKeyReleased;
        }

        private void OnJumpKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<JumpingState>();

        private void OnWalkKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<WalkingState>();
        
        private void OnWalkKeyReleased(InputAction.CallbackContext context)
        {
            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else
                StateSwitcher.SwitchState<RunningState>();
        }

        private void OnSprintKeyPressed(InputAction.CallbackContext context){
            StateSwitcher.SwitchState<SprintingState>();
        }
        
        private void OnSprintKeyReleased(InputAction.CallbackContext context)
        {
            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else
                StateSwitcher.SwitchState<RunningState>();
        }
    }
}