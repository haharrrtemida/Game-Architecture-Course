using UnityEngine;

namespace hw2
{  
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;
        private readonly Character _character;

        public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
        {
            StateSwitcher = stateSwitcher;
            _character = character;
            Data = data;
        }

        protected CharacterInput Input => _character.Input;
        protected CharacterController CharacterController => _character.CharacterController;
        protected CharacterView View => _character.View;

        private Quaternion TurnRight => Quaternion.Euler(Vector3.zero);
        private Quaternion TurnLeft => Quaternion.Euler(Vector3.up * 180);

        public virtual void Enter()
        {
            Debug.Log(GetType());
            AddInputActionsCallbacks();
        }

        public virtual void Exit()
        {
            RemoveInputActionsCallbacks();
        }

        public void HandleInput()
        {
            Data.XInput = ReadHorizontalInput();
            Data.XVelocity = Data.XInput * Data.Speed;
        }


        public virtual void Update()
        {
            Vector3 velocity = GetConvertedVelocity();
            
            CharacterController.Move(velocity * Time.deltaTime);
            _character.transform.rotation = GetRotationFrom(velocity);
        }

        protected bool IsHorizontalInputZero() => Data.XInput == 0;
        protected virtual void AddInputActionsCallbacks() { }
        protected virtual void RemoveInputActionsCallbacks() { }

        private Quaternion GetRotationFrom(Vector3 velocity)
        {
            if (velocity.x > 0)
                return TurnRight;
            else if (velocity.x < 0)
                return TurnLeft;
            
            return _character.transform.rotation;
        }

        private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity);
        private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
    }
}