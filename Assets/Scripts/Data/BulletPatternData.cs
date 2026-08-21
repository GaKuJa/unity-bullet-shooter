using UnityEngine;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "BulletPatternData", menuName = "Bullet Shooter/Bullet Pattern Data")]
    public class BulletPatternData : ScriptableObject
    {
        [SerializeField] private float fireInterval = 0.2f;

        public float FireInterval => fireInterval;
    }
}
