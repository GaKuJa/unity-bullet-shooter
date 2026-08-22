using Shooter.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Shooter.Core
{
    public class ProjectInstaller : MonoInstaller
    {
        [FormerlySerializedAs("inputReader")]
        [SerializeField] private InputReader _inputReader;

        public override void InstallBindings()
        {
            Container.Bind<IInputReader>().FromInstance(_inputReader);
        }
    }
}
