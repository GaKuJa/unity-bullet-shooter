using UnityEngine;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "MainGameSettings", menuName = "Bullet Shooter/Main Game Settings")]
    public class MainGameSettings : ScriptableObject
    {
        [SerializeField] private float _respawnDelay = 3f;

        public float RespawnDelay => _respawnDelay;
    }
}
