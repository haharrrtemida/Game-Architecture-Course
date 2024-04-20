using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    [SerializeField] private PlayerMotor _player;
    [SerializeField] private CameraRotator _rotator;
    private Vector3 _inputDirection;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _inputDirection.x = Input.GetAxis(HORIZONTAL);
        _inputDirection.z = Input.GetAxis(VERTICAL);
        
        _player.AddMovement(_inputDirection);
        _rotator.Look(Input.mousePositionDelta);
    }
}