using Shooter.Input;
using UnityEngine;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        private IInputReader inputReader;

        [SerializeField] private Mover mover;

        [Inject]
        public void Construct(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        private void Update()
        {
            mover.Move(inputReader.MoveDirection, Time.deltaTime);
        }
    }
}
