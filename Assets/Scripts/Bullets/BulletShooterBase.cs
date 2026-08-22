using UnityEngine;

namespace Shooter.Bullets
{
    public abstract class BulletShooterBase : MonoBehaviour
    {
        private float _fireInterval;
        private float _fireCooldown;

        public void SetFireInterval(float fireInterval)
        {
            _fireInterval = fireInterval;
        }

        private void Update()
        {
            _fireCooldown -= Time.deltaTime;
        }

        public virtual void Fire()
        {
            if (_fireCooldown > 0f)
            {
                return;
            }

            LaunchBullet();
            _fireCooldown = _fireInterval;
        }

        protected abstract void LaunchBullet();
    }
}
