using Shooter.Data;
using Shooter.Player;
using UnityEngine;
using Zenject;

namespace Shooter.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyData _data;

        [SerializeField] private PathMover _mover;

        [SerializeField] private EnemyBulletShooter _shooter;

        private Transform _playerTransform;

        [Inject]
        public void Construct(PlayerController player)
        {
            _playerTransform = player.transform;
        }

        private void Awake()
        {
            _mover.Initialize(_data.MoveSpeed);
            _shooter.Initialize(_playerTransform);
            _shooter.SetFireInterval(_data.FireInterval);
        }

        private void Start()
        {
            _mover.MoveStart();
        }

        private void Update()
        {
            _shooter.Fire();
        }
    }
}
