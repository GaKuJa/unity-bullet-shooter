using Shooter.Data;
using Shooter.Player;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class MainGameInstaller : MonoInstaller
    {
        [SerializeField] private MainGameSettings _settings;

        [SerializeField] private PlayerController _player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromInstance(_player);
            Container.Bind<MainGameSettings>().FromInstance(_settings);
        }
    }
}
