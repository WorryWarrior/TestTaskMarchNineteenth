using Content.Infrastructure.States;
using Content.Infrastructure.States.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Content.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button startGameButton = null;

        private IStateMachine _gameStateMachine;

        public void Construct(
            IStateMachine gameStateMachine
            )
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            startGameButton.onClick.AddListener(() => _gameStateMachine.Enter<GameLoopState>());
        }
    }
}