using Shooter.Bullets;
using UnityEngine;

namespace Shooter.Enemy
{
    public class EnemyBulletShooter : BulletShooterBase
    {
        [SerializeField] private AimedBullet _bulletPrefab;

        [SerializeField] private Transform _container;
        [SerializeField] private Transform _firePoint;
        private Transform _target;

        [SerializeField] private int _initialSize = 10;

        private BulletPool<AimedBullet> _pool;

        private void Awake()
        {
            _pool = new BulletPool<AimedBullet>(_bulletPrefab, _container, _initialSize);
        }

        public void Initialize(Transform target)
        {
            _target = target;
        }

        protected override void LaunchBullet()
        {
            var bullet = _pool.Rent();
            bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
            bullet.SetTarget(_target);
            bullet.Fire();
        }
    }
}
