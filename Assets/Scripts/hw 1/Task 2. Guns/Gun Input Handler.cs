using System;
using UnityEngine;

public class GunInputHandler : MonoBehaviour
{
    public event Action<Gun> OnGunChanged;
    public event Action<Gun> OnGunInfoChanged;
    [SerializeField] private Gun _currentGun;
    [SerializeField] private Gun[] _guns;

    public Gun CurrentGun => _currentGun;

    private void Awake()
    {
        SwitchGun(_guns[0]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentGun.Fire();
            OnGunInfoChanged?.Invoke(_currentGun);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentGun.Reload();
            OnGunInfoChanged?.Invoke(_currentGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(_guns[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchGun(_guns[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchGun(_guns[2]);
        }
    }

    private void SwitchGun(Gun weapon)
    {
        _currentGun?.Unequip();
        _currentGun = weapon;
        _currentGun.Equip();
        OnGunChanged?.Invoke(_currentGun);
    }
}