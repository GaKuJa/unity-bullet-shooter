using R3;
using System;

namespace Shooter.Core
{
    public interface IHealthModel
    {
        int MaxHp { get; }
        bool IsDead { get; }
        Observable<int> CurrentHp { get; }
        event Action OnDied;
    }
}
