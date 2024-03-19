using UnityEngine;

namespace Content.Gameplay
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float disableDelay = 10f;
        public Vector3 velocity;

        private void Update()
        {
            transform.position += velocity * (speed * Time.deltaTime);
        }

        public void TriggerDisable()
        {
            Invoke(nameof(DisableSelf), disableDelay);
        }

        private void DisableSelf()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            HealthBase otherHealth = other.GetComponentInParent<HealthBase>();

            if (otherHealth != null)
            {
                otherHealth.TakeDamage();
                gameObject.SetActive(false);
            }
        }
    }
}