using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _visionAngle;
    [SerializeField] private Transform _controlledCamera;
    private float _xRotation, _yRotation;

    public void Look(Vector2 offset)
    {
        _xRotation -= offset.y * _sensitivity;
        _yRotation = offset.x * _sensitivity;

        _xRotation = Mathf.Clamp(_xRotation, -_visionAngle, _visionAngle);
        transform.Rotate(Vector3.up * _yRotation);
        _controlledCamera.localRotation = Quaternion.Euler(Vector3.right * _xRotation);
    }
}