using R3;
using Shooter.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.UI
{
    public class HealthGaugeView : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        public void Bind(IHealthModel health)
        {
            health.CurrentHp
                .Subscribe(hp => _fillImage.fillAmount = (float)hp / health.MaxHp)
                .AddTo(this);
        }
    }
}
