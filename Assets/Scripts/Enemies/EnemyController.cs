using Shooter.Data;
using UnityEngine;

namespace Shooter.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyData data;
        [SerializeField] private PathMover mover;

        private void Awake()
        {
            mover.Initialize(data.MoveSpeed);
        }

        private void Start()
        {
            mover.MoveStart();
        }
    }
}
