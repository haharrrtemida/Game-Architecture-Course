using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Ball : MonoBehaviour
{
    public event Action<Ball> OnBallClicked;
    
    [SerializeField] private BallColor _ballColor;
    private MeshRenderer _renderer;

    public BallColor BallColor => _ballColor;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        OnBallClicked?.Invoke(this);
    }

    public void Initialize(BallColor color, Material material)
    {
        _ballColor = color;
        SetMaterial(material);
    }
    
    private void SetMaterial(Material material)
    {
        _renderer.material = material;
    }
}

public enum BallColor
{
    Red,
    White,
    Green
}