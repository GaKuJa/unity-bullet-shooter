using Shooter.Core;
using Shooter.Data;
using Shooter.Player;
using Shooter.UI;
using UnityEngine;
using Zenject;

namespace Shooter.Enemy
{
    public class EnemyController : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyData _data;

        [SerializeField] private PathMover _mover;

        [SerializeField] private EnemyBulletShooter _shooter;

        [SerializeField] private HealthGaugeView _healthGauge;

        private readonly HealthModel _health = new HealthModel();

        private Transform _playerTransform;
        private IHealthModel _playerHealth;

        [Inject]
        public void Construct(PlayerController player)
        {
            _playerTransform = player.transform;
            _playerHealth = player.Health;
        }

        private void Awake()
        {
            _mover.Initialize(_data.MoveSpeed);
            _shooter.Initialize(_playerTransform);
            _shooter.SetFireInterval(_data.FireInterval);
            _health.Initialize(_data.MaxHealth);
            _healthGauge.Bind(_health);
        }

        private void Start()
        {
            _mover.MoveStart();
        }

        private void Update()
        {
            if (!_playerHealth.IsDead)
            {
                _shooter.Fire();
            }
        }

        public void TakeDamage(int amount)
        {
            _health.DecrementHp(amount);
        }
    }
}
