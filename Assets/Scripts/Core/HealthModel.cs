using R3;
using System;

namespace Shooter.Core
{
    public class HealthModel : IHealthModel
    {
        private readonly ReactiveProperty<int> _currentHp = new ReactiveProperty<int>();

        public int MaxHp { get; private set; }
        public bool IsDead => _currentHp.Value <= 0;
        public Observable<int> CurrentHp => _currentHp;

        public event Action OnDied;

        public void Initialize(int maxHp)
        {
            MaxHp = maxHp;
            _currentHp.Value = maxHp;
        }

        public void DecrementHp(int amount)
        {
            if (IsDead)
            {
                return;
            }

            int next = _currentHp.Value - amount;
            _currentHp.Value = next < 0 ? 0 : next;

            if (_currentHp.Value == 0)
            {
                OnDied?.Invoke();
            }
        }

        public void Revive()
        {
            _currentHp.Value = MaxHp;
        }
    }
}
