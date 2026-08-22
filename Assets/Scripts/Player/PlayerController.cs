using Shooter.Core;
using Shooter.Data;
using Shooter.Input;
using Shooter.UI;
using UnityEngine;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        private IInputReader _inputReader;

        [SerializeField] private PlayerData _data;

        [SerializeField] private Mover _mover;

        [SerializeField] private PlayerBulletShooter _shooter;

        [SerializeField] private HealthGaugeView _healthGauge;

        private readonly HealthModel _health = new HealthModel();

        public IHealthModel Health => _health;

        [Inject]
        public void Construct(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        private void Awake()
        {
            _shooter.SetFireInterval(_data.FireInterval);
            _health.Initialize(_data.MaxHealth);
            _healthGauge.Bind(_health);
            _health.OnDied += HandleDied;
        }

        private void Update()
        {
            _mover.Move(_inputReader.MoveDirection, Time.deltaTime);

            if (_inputReader.IsFiring)
            {
                _shooter.Fire();
            }
        }

        public void TakeDamage(int amount)
        {
            _health.DecrementHp(amount);
        }

        public void Respawn()
        {
            gameObject.SetActive(true);
            _health.Revive();
        }

        private void HandleDied()
        {
            gameObject.SetActive(false);
        }
    }
}
