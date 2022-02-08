using UnityEngine;

namespace CameraFeatures
{
    [AddComponentMenu("Camera/Borders checker")]
    public class CameraBordersChecker : MonoBehaviour
    {
        public static float screenInCameraCoordsX;
        public static float screenInCameraCoordsY;
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
            screenInCameraCoordsX = _camera.aspect * _camera.orthographicSize;
            screenInCameraCoordsY = _camera.orthographicSize;
        }
    }
}