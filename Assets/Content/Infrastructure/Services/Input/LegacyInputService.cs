using UnityEngine;

namespace Content.Infrastructure.Services.Input
{
    public class LegacyInputService : IInputService
    {
        private Camera _mainCam;

        private Camera MainCam
        {
            get
            {
                if (_mainCam == null)
                    _mainCam = UnityEngine.Camera.main;

                return _mainCam;
            }
        }

        public Vector3 MousePosition => UnityEngine.Input.mousePosition;

        public Vector3 GetMouseWorldPosition()
        {
            Vector3 targetPosition = MousePosition;
            targetPosition.z = MainCam.transform.position.y;

            Vector3 mouseWorldPosition = MainCam.ScreenToWorldPoint(targetPosition);
            mouseWorldPosition.y = 0;

            return mouseWorldPosition;
        }
    }
}