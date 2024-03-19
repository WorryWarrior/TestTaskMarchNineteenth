using UnityEngine;

namespace Content.Gameplay
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private Vector3 velocity = default;
        [SerializeField] private float speed = 1f;

        private void Update()
        {
            transform.position += velocity * speed * Time.deltaTime;
        }
    }
}