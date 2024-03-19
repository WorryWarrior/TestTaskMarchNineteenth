using Content.Gameplay;
using Content.Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace Content.Infrastructure.Services.Gameplay
{
    public class GameplayService : IGameplayService
    {
        private const int BulletPoolSize = 100;

        private readonly IGameplayFactory _gameplayFactory;
        private GameplayObjectPool<BulletController> _bulletPool;

        public GameplayService(
            IGameplayFactory gameplayFactory)
        {
            _gameplayFactory = gameplayFactory;
        }

        public void Initialize()
        {
            CreateBulletPool();
        }

        public PlayerController CreatePlayer()
        {
            PlayerController playerController = _gameplayFactory.CreatePlayer();
            playerController.GetComponent<ShootingController>().Construct(this);
            return playerController;
        }

        public EnemyController CreateEnemy()
        {
            EnemyController enemyController = _gameplayFactory.CreateEnemy();
            enemyController.GetComponent<ShootingController>().Construct(this);

            return enemyController;
        }

        public BulletController CreateBullet()
        {
            return _bulletPool.GetObject(out int _);
        }

        private void CreateBulletPool()
        {
            Transform bulletParent = new GameObject("Bullet Pool").transform;

            _bulletPool = new GameplayObjectPool<BulletController>(BulletPoolSize);
            _bulletPool.CreatePool(() => _gameplayFactory.CreateBullet(), it =>
            {
                it.gameObject.SetActive(false);
                it.transform.SetParent(bulletParent);
            });
        }
    }
}