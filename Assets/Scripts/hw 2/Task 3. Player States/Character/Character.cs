using UnityEngine;

namespace hw2.task3.PlayerState
{  
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterConfig _config;
        [SerializeField] private CharacterView _view;
        [SerializeField] private GroundChecker _groundChecker;
        private CharacterInput _input;
        private CharacterStateMachine _stateMachine;
        private CharacterController _characterController;
        
        public CharacterInput Input => _input;
        public CharacterController CharacterController => _characterController;
        public CharacterConfig Config => _config;
        public CharacterView View => _view;
        public GroundChecker GroundChecker => _groundChecker;

        private void Awake()
        {
            _view.Initialize();
            _input = new CharacterInput();
            _characterController = GetComponent<CharacterController>();
            _stateMachine = new CharacterStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }

        private void OnEnable() => _input.Enable();
        private void OnDisable() => _input.Disable();
    }
}