using Content.Gameplay;
using UnityEngine;

namespace Content.Infrastructure.Factories.Interfaces
{
    public interface IGameplayFactory : IService
    {
        PlayerController CreatePlayer();
        BulletController CreateBullet();
        EnemyController CreateEnemy();
    }
}