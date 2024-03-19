using UnityEngine;

namespace Content.Gameplay
{
    public abstract class HealthBase : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;

        protected int CurrentHealth { get; set; }

        public abstract void TakeDamage();

        public void Initialize()
        {
            CurrentHealth = maxHealth;
        }
    }
}