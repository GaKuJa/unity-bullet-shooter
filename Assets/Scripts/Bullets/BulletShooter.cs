using Shooter.Data;
using Shooter.Pooling;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Bullets
{
    public class BulletShooter : MonoBehaviour
    {
        [FormerlySerializedAs("pattern")]
        [SerializeField] private BulletPatternData _pattern;

        [FormerlySerializedAs("firePoint")]
        [SerializeField] private Transform _firePoint;

        [FormerlySerializedAs("bulletPrefab")]
        [SerializeField] private BulletBase _bulletPrefab;

        [FormerlySerializedAs("poolContainer")]
        [SerializeField] private Transform _poolContainer;

        [FormerlySerializedAs("poolInitialSize")]
        [SerializeField] private int _poolInitialSize = 20;

        private ObjectPool<BulletBase> _bulletPool;
        private float _fireCooldown;

        private void Awake()
        {
            _bulletPool = new ObjectPool<BulletBase>(_bulletPrefab, _poolContainer, _poolInitialSize, bullet => bullet.Initialize(ReturnToPool));
        }

        private void Update()
        {
            _fireCooldown -= Time.deltaTime;
        }

        public void Fire()
        {
            if (_fireCooldown > 0f)
            {
                return;
            }

            LaunchBullet();
            _fireCooldown = _pattern.FireInterval;
        }

        public void Fire(Vector3 targetPosition)
        {
            if (_fireCooldown > 0f)
            {
                return;
            }

            AimedBullet bullet = (AimedBullet)LaunchBullet();
            bullet.SetTarget(targetPosition);
            _fireCooldown = _pattern.FireInterval;
        }

        private BulletBase LaunchBullet()
        {
            BulletBase bullet = _bulletPool.Rent();
            bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
            bullet.Launch();
            return bullet;
        }

        private void ReturnToPool(BulletBase bullet)
        {
            _bulletPool.Return(bullet);
        }
    }
}
