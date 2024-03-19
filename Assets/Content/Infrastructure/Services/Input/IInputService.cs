using UnityEngine;

namespace Content.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector3 MousePosition { get; }

        Vector3 GetMouseWorldPosition();
    }
}