using Cysharp.Threading.Tasks;
using Shooter.Data;
using System;
using UnityEngine;
using Zenject;

namespace Shooter.Player
{
    public class PlayerRespawnManager : MonoBehaviour
    {
        private PlayerController _player;
        private MainGameSettings _settings;

        [Inject]
        public void Construct(PlayerController player, MainGameSettings settings)
        {
            _player = player;
            _settings = settings;
        }

        private void Awake()
        {
            _player.Health.OnDied += Respawn;
        }

        private void OnDestroy()
        {
            _player.Health.OnDied -= Respawn;
        }

        private void Respawn() => UniTask.Void(async () =>
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.RespawnDelay));
            _player.Respawn();
        });
    }
}
