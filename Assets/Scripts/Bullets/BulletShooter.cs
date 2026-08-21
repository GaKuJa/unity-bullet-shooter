using Shooter.Data;
using Shooter.Pooling;
using UnityEngine;

namespace Shooter.Bullets
{
    public class BulletShooter : MonoBehaviour
    {
        [SerializeField] private BulletPatternData pattern;
        [SerializeField] private Transform firePoint;
        [SerializeField] private BulletBase bulletPrefab;
        [SerializeField] private Transform poolContainer;
        [SerializeField] private int poolInitialSize = 20;

        private ObjectPool<BulletBase> bulletPool;
        private float fireCooldown;

        private void Awake()
        {
            bulletPool = new ObjectPool<BulletBase>(bulletPrefab, poolContainer, poolInitialSize, bullet => bullet.Initialize(ReturnToPool));
        }

        private void Update()
        {
            fireCooldown -= Time.deltaTime;
        }

        public void Fire()
        {
            if (fireCooldown > 0f)
            {
                return;
            }

            LaunchBullet();
            fireCooldown = pattern.FireInterval;
        }

        private void LaunchBullet()
        {
            BulletBase bullet = bulletPool.Rent();
            bullet.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
            bullet.Launch();
        }

        private void ReturnToPool(BulletBase bullet)
        {
            bulletPool.Return(bullet);
        }
    }
}
