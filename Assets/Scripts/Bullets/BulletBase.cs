using Shooter.Core;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Bullets
{
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        [FormerlySerializedAs("Speed")]
        [SerializeField] protected float _speed = 10f;

        private Camera _viewCamera;
        private Action<BulletBase> _onDespawned;
        private bool _hasDespawned;

        private void Awake()
        {
            _viewCamera = Camera.main;
        }

        protected virtual void Update()
        {
            if (IsOffScreen())
            {
                Despawn();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IDamageable damageable))
            {
                return;
            }

            damageable.TakeDamage(_damage);
            Despawn();
        }

        public void Initialize(Action<BulletBase> despawnedCallback)
        {
            _onDespawned = despawnedCallback;
        }

        public void Launch()
        {
            _hasDespawned = false;
        }

        private void Despawn()
        {
            if (_hasDespawned)
            {
                return;
            }

            _hasDespawned = true;
            _onDespawned?.Invoke(this);
        }

        private bool IsOffScreen()
        {
            Vector3 viewportPosition = _viewCamera.WorldToViewportPoint(transform.position);
            return viewportPosition.x < 0f || viewportPosition.x > 1f || viewportPosition.y < 0f || viewportPosition.y > 1f;
        }
    }
}
