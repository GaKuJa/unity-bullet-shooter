using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Bullet Shooter/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _fireInterval = 2f;

        public float MoveSpeed => _moveSpeed;
        public float FireInterval => _fireInterval;
    }
}
