using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Bullet Shooter/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _fireInterval = 2f;
        [SerializeField] private int _maxHealth = 3;

        public float MoveSpeed => _moveSpeed;
        public float FireInterval => _fireInterval;
        public int MaxHealth => _maxHealth;
    }
}
