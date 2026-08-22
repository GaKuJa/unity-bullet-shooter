using UnityEngine;
using UnityEngine.Serialization;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Bullet Shooter/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [FormerlySerializedAs("moveSpeed")]
        [SerializeField] private float _moveSpeed = 2f;

        public float MoveSpeed => _moveSpeed;
    }
}
