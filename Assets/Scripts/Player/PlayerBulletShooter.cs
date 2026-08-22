using Shooter.Bullets;
using UnityEngine;

namespace Shooter.Player
{
    public class PlayerBulletShooter : BulletShooterBase
    {
        [SerializeField] private BulletBase _bulletPrefab;

        [SerializeField] private Transform _container;
        [SerializeField] private Transform _firePoint;

        [SerializeField] private int _initialSize = 10;

        private BulletPool<BulletBase> _pool;

        private void Awake()
        {
            _pool = new BulletPool<BulletBase>(_bulletPrefab, _container, _initialSize);
        }

        protected override void LaunchBullet()
        {
            var bullet = _pool.Rent();
            bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
            bullet.Fire();
        }
    }
}
