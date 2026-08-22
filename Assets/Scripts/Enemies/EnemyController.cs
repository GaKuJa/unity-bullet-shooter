using Shooter.Bullets;
using Shooter.Data;
using Shooter.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Shooter.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [FormerlySerializedAs("data")]
        [SerializeField] private EnemyData _data;

        [FormerlySerializedAs("mover")]
        [SerializeField] private PathMover _mover;

        [FormerlySerializedAs("shooter")]
        [SerializeField] private BulletShooter _shooter;

        private Transform _playerTransform;

        [Inject]
        public void Construct(PlayerController player)
        {
            _playerTransform = player.transform;
        }

        private void Awake()
        {
            _mover.Initialize(_data.MoveSpeed);
        }

        private void Start()
        {
            _mover.MoveStart();
        }

        private void Update()
        {
            _shooter.Fire(_playerTransform.position);
        }
    }
}
