using UnityEngine;

namespace hw1.task2
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        private void Awake()
        {
            Destroy(gameObject, _lifetime);
        }
    }
}