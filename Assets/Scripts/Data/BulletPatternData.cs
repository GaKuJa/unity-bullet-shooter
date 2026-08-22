using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "BulletPatternData", menuName = "Bullet Shooter/Bullet Pattern Data")]
    public class BulletPatternData : ScriptableObject
    {
        [FormerlySerializedAs("fireInterval")]
        [SerializeField] private float _fireInterval = 0.2f;

        public float FireInterval => _fireInterval;
    }
}
