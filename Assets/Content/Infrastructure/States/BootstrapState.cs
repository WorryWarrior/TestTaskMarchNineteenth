using Content.Infrastructure.States.Interfaces;

namespace Content.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;

        public BootstrapState(
            IStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadMenuState>();
        }

        public void Exit()
        {

        }
    }
}