using UnityEngine;

namespace Shooter.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private Camera viewCamera;

        private void Awake()
        {
            if (viewCamera == null)
            {
                viewCamera = Camera.main;
            }
        }

        public void Move(Vector2 direction, float deltaTime)
        {
            Vector3 nextPosition = transform.position + (Vector3)direction * speed * deltaTime;
            transform.position = ClampToScreen(nextPosition);
        }

        private Vector3 ClampToScreen(Vector3 position)
        {
            Vector3 viewportPosition = viewCamera.WorldToViewportPoint(position);
            viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
            viewportPosition.y = Mathf.Clamp01(viewportPosition.y);
            return viewCamera.ViewportToWorldPoint(viewportPosition);
        }
    }
}
