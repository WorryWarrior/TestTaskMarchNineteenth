using System.Collections;
using Content.Infrastructure.Services.Gameplay;
using UnityEngine;

namespace Content.Gameplay
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private Transform[] bulletOrigins = null;
        [SerializeField] private Vector3 bulletVelocity = default;
        [SerializeField] private float shootingFrequency = .25f;

        private IGameplayService _gameplayService;

        public void Construct(
            IGameplayService gameplayService
            )
        {
            _gameplayService = gameplayService;
        }

        public void Initialize()
        {
            StopAllCoroutines();
            StartCoroutine(ShootRoutine());
        }

        private IEnumerator ShootRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(shootingFrequency);

                for (int i = 0; i < bulletOrigins.Length; i++)
                {
                    BulletController controller = _gameplayService.CreateBullet();
                    controller.velocity = bulletVelocity;
                    controller.transform.position = bulletOrigins[i].position;
                    controller.TriggerDisable();
                }
            }
        }
    }
}