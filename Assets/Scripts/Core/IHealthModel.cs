using R3;

namespace Shooter.Core
{
    public interface IHealthModel
    {
        int MaxHp { get; }
        Observable<int> CurrentHp { get; }
    }
}
