using Content.Infrastructure.Factories.Interfaces;
using Content.Infrastructure.SceneManagement;
using Content.Infrastructure.States.Interfaces;
using Content.UI;

namespace Content.Infrastructure.States
{
    public class LoadMenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;

        public LoadMenuState(
            ISceneLoader sceneLoader,
            IStateMachine gameStateMachine,
            IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneName.Core, OnMenuSceneLoaded);
        }

        public void Exit()
        {

        }

        private void OnMenuSceneLoaded(SceneName _)
        {
            CreateMenuHUD();
        }

        private void CreateMenuHUD()
        {
            _uiFactory.CreateUIRoot();

            MainMenuController mainMenuController = _uiFactory.CreateMainMenuHUD();
            mainMenuController.Initialize();
        }
    }
}