using Content.Gameplay;
using Content.Infrastructure.Factories.Interfaces;
using Content.Infrastructure.Services.Input;
using Content.Infrastructure.States.Interfaces;
using UnityEngine;

namespace Content.Infrastructure.Factories
{
    public class GameplayFactory : IGameplayFactory
    {
        private readonly GameObject _playerPrefab;
        private readonly GameObject _enemyPrefab;
        private readonly GameObject _bulletPrefab;
        private readonly IInputService _inputService;
        private readonly IStateMachine _stateMachine;

        public GameplayFactory(
            GameObject playerPrefab,
            GameObject enemyPrefab,
            GameObject bulletPrefab,
            IInputService inputService,
            IStateMachine stateMachine)
        {
            _playerPrefab = playerPrefab;
            _enemyPrefab = enemyPrefab;
            _bulletPrefab = bulletPrefab;
            _inputService = inputService;
            _stateMachine = stateMachine;
        }


        public PlayerController CreatePlayer()
        {
            PlayerController playerController = Object.Instantiate(_playerPrefab).GetComponent<PlayerController>();
            playerController.GetComponent<PlayerMovementController>().Construct(_inputService);
            playerController.GetComponent<PlayerHealth>().Construct(_stateMachine);
            playerController.GetComponent<PlayerHealth>().Initialize();

            return playerController;
        }

        public BulletController CreateBullet()
        {
            BulletController bulletController = Object.Instantiate(_bulletPrefab).GetComponent<BulletController>();
            return bulletController;
        }

        public EnemyController CreateEnemy()
        {
            EnemyController enemyController = Object.Instantiate(_enemyPrefab).GetComponent<EnemyController>();
            enemyController.GetComponent<EnemyHealth>().Construct(_stateMachine);
            enemyController.GetComponent<EnemyHealth>().Initialize();
            return enemyController;
        }
    }
}