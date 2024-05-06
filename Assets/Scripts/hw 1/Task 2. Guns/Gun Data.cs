using UnityEngine;

namespace hw1.task2
{
    [CreateAssetMenu(fileName = "New Gun Data", menuName = "hw1/Gun Data")]
    public class GunData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int BulletsPerShot { get; private set; }
        [field: SerializeField] public float FireForce { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public bool IsInfinite { get; private set; }
        [field: SerializeField] public Projectile Projectile { get; private set; }
        [field: SerializeField] public int BulletsInClip { get; private set; }
    }
}