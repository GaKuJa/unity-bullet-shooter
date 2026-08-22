using Shooter.Pooling;
using UnityEngine;

namespace Shooter.Bullets
{
    public class BulletPool<T> : ObjectPool<T> where T : BulletBase
    {
        public BulletPool(T prefab, Transform parent, int initialSize) : base(prefab, parent, initialSize)
        {
        }

        protected override T CreateInstance()
        {
            var instance = base.CreateInstance();
            instance.OnDespawned += ReturnBullet;
            return instance;
        }

        private void ReturnBullet(BulletBase bullet)
        {
            base.Return((T)bullet);
        }
    }
}
