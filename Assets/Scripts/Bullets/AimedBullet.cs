using UnityEngine;

namespace Shooter.Bullets
{
    public class AimedBullet : BulletBase
    {
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public override void Fire()
        {
            LookAtTarget();
            base.Fire();
        }

        private void LookAtTarget()
        {
            Vector2 direction = _target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
