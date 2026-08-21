using Shooter.Input;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private InputReader inputReader;

        public override void InstallBindings()
        {
            Container.Bind<IInputReader>().FromInstance(inputReader);
        }
    }
}
