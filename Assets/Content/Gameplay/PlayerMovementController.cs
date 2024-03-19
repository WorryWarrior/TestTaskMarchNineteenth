using Content.Infrastructure.Services.Input;
using UnityEngine;

namespace Content.Gameplay
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Vector3 movementOffset = default;

        private IInputService _inputService;

        public void Construct(
            IInputService inputService
            )
        {
            _inputService = inputService;
        }

        private void Update()
        {
            transform.position = _inputService.GetMouseWorldPosition() + movementOffset;
        }
    }
}