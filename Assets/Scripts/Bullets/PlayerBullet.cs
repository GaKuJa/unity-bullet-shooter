using Shooter.Core;
using UnityEngine;

namespace Shooter.Bullets
{
    public class PlayerBullet : BulletBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IDamageable damageable))
            {
                return;
            }

            damageable.TakeDamage(damage);
            Despawn();
        }
    }
}
