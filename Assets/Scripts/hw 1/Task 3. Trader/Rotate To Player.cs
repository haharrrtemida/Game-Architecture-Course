using UnityEngine;

namespace hw1.task3
{
    public class RotateToPlayer : MonoBehaviour
    {
        private Transform _target;

        private void Awake()
        {
            // Решил сделать так, чтобы не прокидывать в каждом объекте
            // игрока через Inspector. Скорее всего решение этой проблемы
            // будет в уроке по Zenject)
            _target = FindFirstObjectByType<PlayerMotor>().transform;
        }

        private void Update()
        {
            Vector3 toTarget = _target.position - transform.position;
            Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
            transform.rotation = Quaternion.LookRotation(toTargetXZ);
        }
    }
}