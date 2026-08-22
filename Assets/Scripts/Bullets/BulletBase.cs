using Shooter.Core;
using System;
using UnityEngine;

namespace Shooter.Bullets
{
    public class BulletBase : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        [SerializeField] protected float _speed = 10f;

        private Camera _viewCamera;

        public event Action<BulletBase> OnDespawned;

        private bool _hasFireRequest;

        private void Awake()
        {
            _viewCamera = Camera.main;
        }

        protected virtual void Update()
        {
            if (!_hasFireRequest)
            {
                return;
            }

            transform.position += transform.up * _speed * Time.deltaTime;

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

        public virtual void Fire()
        {
            _hasFireRequest = true;
        }

        private void Despawn()
        {
            if (!_hasFireRequest)
            {
                return;
            }

            _hasFireRequest = false;
            OnDespawned?.Invoke(this);
        }

        private bool IsOffScreen()
        {
            Vector3 viewportPosition = _viewCamera.WorldToViewportPoint(transform.position);
            return viewportPosition.x < 0f || viewportPosition.x > 1f || viewportPosition.y < 0f || viewportPosition.y > 1f;
        }
    }
}
