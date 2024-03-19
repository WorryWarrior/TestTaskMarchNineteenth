using Content.UI;

namespace Content.Infrastructure.Factories.Interfaces
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        MainMenuController CreateMainMenuHUD();
    }
}