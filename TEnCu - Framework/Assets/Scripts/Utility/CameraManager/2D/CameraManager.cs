﻿using UnityEngine;

namespace Utility.CameraManager._2D
{
    public class CameraManager: Utility.CameraManager.CameraManager
    {
        protected override void ManageInput()
        {
            switch (Input.touchCount)
            {
                case 1:
                    var touch = Input.GetTouch(0);
                    if (touch.phase != TouchPhase.Moved) return;
                    Scroll(touch.deltaPosition);
                    break;
                case 2:
                    var touchZero = Input.GetTouch(0);
                    var touchOne = Input.GetTouch(1);
                    var touchZeroCurrentPosition = touchZero.position;
                    var touchOneCurrentPosition = touchOne.position;
                    var touchZeroPreviousPosition = touchZeroCurrentPosition - touchZero.deltaPosition;
                    var touchOnePreviousPosition = touchOneCurrentPosition - touchOne.deltaPosition;
                    Zoom(touchZeroCurrentPosition, touchOneCurrentPosition, touchZeroPreviousPosition, touchOnePreviousPosition);
                    break;
            }
        }

        protected sealed override void Scroll(Vector2 deltaPosition)
        {
            var xTranslation = deltaPosition.x * cameraConfigs.speedModifier.rotation;
            var yTranslation = deltaPosition.y * cameraConfigs.speedModifier.rotation;

            xTranslation = Mathf.Round(xTranslation);
            yTranslation = Mathf.Round(yTranslation);

            var currentPosition = cam.transform.position + new Vector3(-xTranslation, -yTranslation, 0);

            //clamp new values between bounds
            var fixedX = Mathf.Clamp(currentPosition.x, cameraConfigs.height.min, cameraConfigs.height.max);
            var fixedY = Mathf.Clamp(currentPosition.y, cameraConfigs.width.min, cameraConfigs.width.max);

            //set camera again with fixed values
            cam.transform.position = new Vector3(fixedX, fixedY, currentPosition.z);
        }
    }
}