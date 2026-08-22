using UnityEngine;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Bullet Shooter/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _fireInterval = 0.2f;

        public float FireInterval => _fireInterval;
    }
}
