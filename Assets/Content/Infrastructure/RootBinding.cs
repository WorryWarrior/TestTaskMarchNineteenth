using Content.Infrastructure.DI;
using Content.Infrastructure.Factories;
using Content.Infrastructure.Factories.Interfaces;
using Content.Infrastructure.SceneManagement;
using Content.Infrastructure.Services.Gameplay;
using Content.Infrastructure.Services.Input;
using Content.Infrastructure.Services.Logging;
using Content.Infrastructure.States;
using Content.Infrastructure.States.Interfaces;
using UnityEngine;

namespace Content.Infrastructure
{
    public class RootBinding : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject uiRootPrefab = null;
        [SerializeField] private GameObject mainMenuPrefab = null;

        [Header("Gameplay")] [Space(20)]
        [SerializeField] private GameObject playerPrefab = null;
        [SerializeField] private GameObject enemyPrefab = null;
        [SerializeField] private GameObject bulletPrefab = null;

        private void Awake()
        {
            RegisterProviders();
            RegisterServices();
            CreateAndRegisterFactories();
            RegisterStates();
        }

        private void RegisterProviders()
        {
            //DIContainer.Container.RegisterService<IAssetProvider>(new AssetProvider());
            DIContainer.Container.RegisterService<ISceneLoader>(new SceneLoader());
        }

        private void CreateAndRegisterFactories()
        {
            DIContainer.Container.RegisterService<IUIFactory>(new UIFactory(uiRootPrefab, mainMenuPrefab));



        }

        private void RegisterServices()
        {
            DIContainer.Container.RegisterService<IInputService>(new LegacyInputService());
            DIContainer.Container.RegisterService<ILoggingService>(new LoggingService());
        }

        private void RegisterStates()
        {
            GameStateMachine gameStateMachine = new GameStateMachine(new StateFactory(),
                DIContainer.Container.GetService<ILoggingService>());

            DIContainer.Container.RegisterService<IStateMachine>(gameStateMachine);


            DIContainer.Container.RegisterService<IGameplayFactory>(new GameplayFactory(playerPrefab, enemyPrefab,
                                                          bulletPrefab, DIContainer.Container.GetService<IInputService>(),
                                                          DIContainer.Container.GetService<IStateMachine>()));
            DIContainer.Container.RegisterService<IGameplayService>(
                new GameplayService(DIContainer.Container.GetService<IGameplayFactory>()));

            gameStateMachine.Initialize();
        }
    }
}