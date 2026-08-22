using R3;

namespace Shooter.Core
{
    public class HealthModel : IHealthModel
    {
        private readonly ReactiveProperty<int> _currentHp = new ReactiveProperty<int>();

        public int MaxHp { get; private set; }
        public Observable<int> CurrentHp => _currentHp;

        public void Initialize(int maxHp)
        {
            MaxHp = maxHp;
            _currentHp.Value = maxHp;
        }

        public void DecrementHp(int amount)
        {
            int next = _currentHp.Value - amount;
            _currentHp.Value = next < 0 ? 0 : next;
        }
    }
}
