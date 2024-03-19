using Content.Infrastructure.States;
using Content.Infrastructure.States.Interfaces;

namespace Content.Gameplay
{
    public class PlayerHealth : HealthBase
    {
        private IStateMachine _stateMachine;

        public void Construct(
            IStateMachine stateMachine
            )
        {
            _stateMachine = stateMachine;
        }


        public override void TakeDamage()
        {
            CurrentHealth--;

            if (CurrentHealth <= 0)
            {
                gameObject.SetActive(false);

                Invoke(nameof(ReturnToMenu), 1f);
            }
        }

        private void ReturnToMenu()
        {
            _stateMachine.Enter<LoadMenuState>();
        }
    }
}