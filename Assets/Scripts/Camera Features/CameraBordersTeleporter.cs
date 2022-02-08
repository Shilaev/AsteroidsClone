using UnityEngine;

namespace CameraFeatures
{
    [AddComponentMenu("Camera/Borders teleporter")]
    public class CameraBordersTeleporter : MonoBehaviour
    {
        public void Update()
        {
            if (CameraBordersChecker.isOutOfBorders(transform)) MoveToOppositeSide();
        }

        private void MoveToOppositeSide()
        {
            var positionX = transform.position.x;
            var positionY = transform.position.y;

            if (positionX > CameraBordersChecker.screenInCameraCoordsX)
                transform.position = new Vector2(-CameraBordersChecker.screenInCameraCoordsX, positionY);
            else if (positionX < -CameraBordersChecker.screenInCameraCoordsX)
                transform.position = new Vector2(CameraBordersChecker.screenInCameraCoordsX, positionY);
            else if (positionY > CameraBordersChecker.screenInCameraCoordsY)
                transform.position = new Vector2(positionX, -CameraBordersChecker.screenInCameraCoordsY);
            else if (positionY < -CameraBordersChecker.screenInCameraCoordsY)
                transform.position = new Vector2(positionX, CameraBordersChecker.screenInCameraCoordsY);
        }
    }
}