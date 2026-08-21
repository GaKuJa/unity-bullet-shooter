using UnityEngine;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Bullet Shooter/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 2f;

        public float MoveSpeed => moveSpeed;
    }
}
