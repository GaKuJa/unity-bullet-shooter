using UnityEngine;

namespace Shooter.Enemies
{
    public class PathMover : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;

        private Vector3[] pathPoints;
        private float speed;
        private int targetPointIndex;
        private bool isMoving;

        public void Initialize(float moveSpeed)
        {
            speed = moveSpeed;
            targetPointIndex = 0;

            pathPoints = new Vector3[waypoints.Length];
            for (int i = 0; i < waypoints.Length; i++)
            {
                pathPoints[i] = waypoints[i].position;
            }

            if (pathPoints.Length > 0)
            {
                transform.position = pathPoints[0];
            }
        }

        public void MoveStart()
        {
            isMoving = true;
        }

        private void Update()
        {
            if (!isMoving)
            {
                return;
            }

            if (targetPointIndex >= pathPoints.Length)
            {
                return;
            }

            Vector3 targetPosition = pathPoints[targetPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                targetPointIndex++;
            }
        }
    }
}
