using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Player
{
    public class Mover : MonoBehaviour
    {
        [FormerlySerializedAs("speed")]
        [SerializeField] private float _speed = 5f;

        [FormerlySerializedAs("viewCamera")]
        [SerializeField] private Camera _viewCamera;

        private void Awake()
        {
            if (_viewCamera == null)
            {
                _viewCamera = Camera.main;
            }
        }

        public void Move(Vector2 direction, float deltaTime)
        {
            Vector3 nextPosition = transform.position + (Vector3)direction * _speed * deltaTime;
            transform.position = ClampToScreen(nextPosition);
        }

        private Vector3 ClampToScreen(Vector3 position)
        {
            Vector3 viewportPosition = _viewCamera.WorldToViewportPoint(position);
            viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
            viewportPosition.y = Mathf.Clamp01(viewportPosition.y);
            return _viewCamera.ViewportToWorldPoint(viewportPosition);
        }
    }
}
