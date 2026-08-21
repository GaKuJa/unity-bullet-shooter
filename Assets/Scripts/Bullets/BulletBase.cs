using System;
using UnityEngine;

namespace Shooter.Bullets
{
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] protected int damage = 1;
        [SerializeField] private float speed = 10f;

        private Camera viewCamera;
        private Action<BulletBase> onDespawned;
        private bool hasDespawned;

        private void Awake()
        {
            viewCamera = Camera.main;
        }

        public void Initialize(Action<BulletBase> despawnedCallback)
        {
            onDespawned = despawnedCallback;
        }

        public void Launch()
        {
            hasDespawned = false;
        }

        private void Update()
        {
            transform.position += transform.up * speed * Time.deltaTime;

            if (IsOffScreen())
            {
                Despawn();
            }
        }

        protected void Despawn()
        {
            if (hasDespawned)
            {
                return;
            }

            hasDespawned = true;
            onDespawned?.Invoke(this);
        }

        private bool IsOffScreen()
        {
            Vector3 viewportPosition = viewCamera.WorldToViewportPoint(transform.position);
            return viewportPosition.x < 0f || viewportPosition.x > 1f || viewportPosition.y < 0f || viewportPosition.y > 1f;
        }
    }
}
