using Shooter.Data;
using Shooter.Input;
using UnityEngine;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        private IInputReader _inputReader;

        [SerializeField] private PlayerData _data;

        [SerializeField] private Mover _mover;

        [SerializeField] private PlayerBulletShooter _shooter;

        [Inject]
        public void Construct(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        private void Awake()
        {
            _shooter.SetFireInterval(_data.FireInterval);
        }

        private void Update()
        {
            _mover.Move(_inputReader.MoveDirection, Time.deltaTime);

            if (_inputReader.IsFiring)
            {
                _shooter.Fire();
            }
        }
    }
}
