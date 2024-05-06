using System.Collections;
using UnityEngine;

namespace hw1.task2
{
    // использовал класс MonoBehaviour, хотя можно было бы избавиться от него, но я использовал
    // корутины. Как можно разрешить эту ситуацию?
    public abstract class Gun : MonoBehaviour
    {
        private const float DELAY_BETWEEN_SHOOTS = .1f;
        [SerializeField] private GunData _data;
        [SerializeField] private Transform _muzzlePoint;
        [SerializeField] private int _bulletsCount;
        private bool _isReadyToShot = true;
        private int _bulletsinClipCount;

        public GunData Data => _data;

        public int BulletsinClipCount
        { 
            get => _bulletsinClipCount;
            private set => _bulletsinClipCount = value;
        }
        public int BulletsCount
        {
            get => _bulletsCount; 
            private set => _bulletsCount = value;
        }

        private void Awake()
        {
            BulletsinClipCount = Data.BulletsInClip;
        }

        public void Fire()
        {
            if (_isReadyToShot == false) return;
            if (BulletsinClipCount <= 0 && Data.IsInfinite != true) return;

            _isReadyToShot = false;
            StartCoroutine(nameof(SpawnProjectiles));
            StartCoroutine(nameof(CountCooldown));
            if (Data.IsInfinite == false)
            {
                BulletsinClipCount--;
            }
        }

        public virtual void Reload()
        {
            if (BulletsinClipCount == Data.BulletsInClip) return;
            
            int bulletsToAdd = Data.BulletsInClip - BulletsinClipCount;
            
            if (BulletsCount >= bulletsToAdd)
            {
                BulletsCount -= bulletsToAdd;
                BulletsinClipCount = Data.BulletsInClip;
            }
            else
            {
                BulletsinClipCount += BulletsCount;
                BulletsCount = 0;
            }
        }

        public void Equip() => gameObject.SetActive(true);

        public void Unequip() => gameObject.SetActive(false);

        private IEnumerator SpawnProjectiles()
        {
            for (int i = 0; i < Data.BulletsPerShot; i++)
            {
                SpawnProjectile();
                yield return new WaitForSeconds(DELAY_BETWEEN_SHOOTS);
            }
        }

        private void SpawnProjectile()
        {
            var projectile = Instantiate(Data.Projectile, _muzzlePoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().AddForce(_muzzlePoint.forward * Data.FireForce, ForceMode.Impulse);
        }

        private IEnumerator CountCooldown()
        {
            yield return new WaitForSeconds(Data.Cooldown);
            _isReadyToShot = true;
        }
    }
}