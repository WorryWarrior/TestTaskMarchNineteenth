using Content.Infrastructure.DI;
using Content.Infrastructure.Factories.Interfaces;
using Content.Infrastructure.States.Interfaces;
using Content.UI;
using UnityEngine;

namespace Content.Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly GameObject _uiRootPrefab;
        private readonly GameObject _mainMenuPrefab;

        private Canvas _uiRoot;

        public UIFactory(
            GameObject uiRootPrefab,
            GameObject mainMenuPrefab)
        {
            _uiRootPrefab = uiRootPrefab;
            _mainMenuPrefab = mainMenuPrefab;
        }


        public void CreateUIRoot()
        {
            _uiRoot = Object.Instantiate(_uiRootPrefab).GetComponent<Canvas>();
        }

        public MainMenuController CreateMainMenuHUD()
        {
            MainMenuController hud = Object.Instantiate(_mainMenuPrefab, _uiRoot.transform).GetComponent<MainMenuController>();
            hud.Construct(DIContainer.Container.GetService<IStateMachine>());

            return hud;
        }
    }
}