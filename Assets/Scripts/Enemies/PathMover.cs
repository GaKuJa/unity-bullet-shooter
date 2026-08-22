using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Enemy
{
    public class PathMover : MonoBehaviour
    {
        [FormerlySerializedAs("waypoints")]
        [SerializeField] private Transform[] _waypoints;

        private Vector3[] _pathPoints;
        private float _speed;
        private int _targetPointIndex;
        private bool _isMoving;

        public void Initialize(float moveSpeed)
        {
            _speed = moveSpeed;
            _targetPointIndex = 0;

            _pathPoints = new Vector3[_waypoints.Length];
            for (int i = 0; i < _waypoints.Length; i++)
            {
                _pathPoints[i] = _waypoints[i].position;
            }

            if (_pathPoints.Length > 0)
            {
                transform.position = _pathPoints[0];
            }
        }

        public void MoveStart()
        {
            _isMoving = true;
        }

        private void Update()
        {
            if (!_isMoving)
            {
                return;
            }

            if (_targetPointIndex >= _pathPoints.Length)
            {
                return;
            }

            Vector3 targetPosition = _pathPoints[_targetPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                _targetPointIndex++;
            }
        }
    }
}
