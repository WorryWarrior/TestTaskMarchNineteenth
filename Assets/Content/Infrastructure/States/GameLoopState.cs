using Content.Gameplay;
using Content.Infrastructure.SceneManagement;
using Content.Infrastructure.Services.Gameplay;
using Content.Infrastructure.States.Interfaces;
using UnityEngine;

namespace Content.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameplayService _gameplayService;
        private readonly IStateMachine _stateMachine;

        public GameLoopState(
            ISceneLoader sceneLoader,
            IGameplayService gameplayService,
            IStateMachine gameStateMachine)
        {
            _sceneLoader = sceneLoader;
            _gameplayService = gameplayService;
            _stateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneName.Core, OnGameSceneLoaded);
            //_stateMachine.Enter<LoadMenuState>();
        }

        public void Exit()
        {
        }

        private void OnGameSceneLoaded(SceneName _)
        {
            _gameplayService.Initialize();

            PlayerController playerController = _gameplayService.CreatePlayer();
            playerController.GetComponent<ShootingController>().Initialize();

            EnemyController enemyController = _gameplayService.CreateEnemy();
            enemyController.GetComponent<ShootingController>().Initialize();
            enemyController.transform.position = new Vector3(0, 0, 25f);
        }
    }
}