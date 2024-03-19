using Content.Gameplay;

namespace Content.Infrastructure.Services.Gameplay
{
    public interface IGameplayService : IService
    {
        void Initialize();
        PlayerController CreatePlayer();
        EnemyController CreateEnemy();
        BulletController CreateBullet();
    }
}