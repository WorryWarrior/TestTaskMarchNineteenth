using Content.Infrastructure.DI;
using Content.Infrastructure.Factories.Interfaces;
using Content.Infrastructure.SceneManagement;
using Content.Infrastructure.Services.Gameplay;
using Content.Infrastructure.States;
using Content.Infrastructure.States.Interfaces;

namespace Content.Infrastructure.Factories
{
    public class StateFactory
    {
        public IExitableState CreateState<T>() where T : IExitableState
        {
            if (typeof(T) == typeof(BootstrapState))
            {
                return new BootstrapState(DIContainer.Container.GetService<IStateMachine>());
            }

            if (typeof(T) == typeof(LoadMenuState))
            {
                return new LoadMenuState(DIContainer.Container.GetService<ISceneLoader>(),
                    DIContainer.Container.GetService<IStateMachine>(),
                    DIContainer.Container.GetService<IUIFactory>());
            }

            if (typeof(T) == typeof(GameLoopState))
            {
                return new GameLoopState(DIContainer.Container.GetService<ISceneLoader>(),
                    DIContainer.Container.GetService<IGameplayService>(),
                    DIContainer.Container.GetService<IStateMachine>());
            }

            return null;
        }
    }
}