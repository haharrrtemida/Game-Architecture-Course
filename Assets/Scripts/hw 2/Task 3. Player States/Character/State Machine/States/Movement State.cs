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
            Data.XZInput = ReadXZInput();
            Data.XZVelocity = Data.XZInput * Data.Speed;
        }


        public virtual void Update()
        {
            Vector3 velocity = GetConvertedVelocity();
            
            CharacterController.Move(velocity * Time.deltaTime);
            var rotation = Quaternion.Lerp(_character.transform.rotation, GetRotationFrom(velocity), 10f * Time.deltaTime);
            _character.transform.rotation = rotation;
        }

        protected bool IsHorizontalInputZero() => Data.XZInput.sqrMagnitude == 0;
        protected virtual void AddInputActionsCallbacks() { }
        protected virtual void RemoveInputActionsCallbacks() { }

        private Quaternion GetRotationFrom(Vector3 velocity)
        {
            Vector3 XZVelocity = new Vector3(velocity.x, 0, velocity.z);
            if (XZVelocity.sqrMagnitude > 0)
                return Quaternion.LookRotation(XZVelocity);
            else
                return _character.transform.rotation;
        }

        private Vector3 GetConvertedVelocity() => new Vector3(Data.XZVelocity.x, Data.YVelocity, Data.XZVelocity.y);
        private Vector2 ReadXZInput() => Input.Movement.Move.ReadValue<Vector2>();
    }
}