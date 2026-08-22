using UnityEngine;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Bullet Shooter/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _fireInterval = 0.2f;
        [SerializeField] private int _maxHealth = 1;

        public float FireInterval => _fireInterval;
        public int MaxHealth => _maxHealth;
    }
}
