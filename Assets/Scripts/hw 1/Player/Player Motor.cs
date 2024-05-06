using UnityEngine;
namespace hw1
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMotor : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 _direction;
        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void AddMovement(Vector3 offset)
        {
            _direction.x = offset.x;
            _direction.z = offset.z;
            _direction = transform.TransformDirection(_direction);
            _controller.Move(_direction * _speed * Time.deltaTime);
        }
    }
}