using Models.ModelConfigurations;
using UnityEngine;

namespace Utility.CameraManager
{
    public abstract class CameraManager : MonoBehaviour
    {
        public CameraConfigs cameraConfigs;
        public Camera cam;
        public GameObject trigger;
        protected const float ThresholdSwipe = 10F;
        protected const float MaximumDifferenceBetweenFingersDuringSlide = 10F;
        private float _fieldOfView;
        protected float startingZEulerAngle;

        private void Start()
        {
            cam = Camera.allCameras[0];
            _fieldOfView = cam.fieldOfView;
            startingZEulerAngle = cam.transform.rotation.eulerAngles.z;
        }

        private void Update()
        {
            if (!trigger.activeSelf) return;
            ManageInput();
        }

        protected virtual void ManageInput() { }

        protected void Zoom(Vector2 currentPosition1, Vector2 currentPosition2, Vector2 previousPosition1, Vector2 previousPosition2)
        {
            // zoom movement detected
            var previousPositionsMagnitude = (previousPosition1 - previousPosition2).magnitude;
            var currentPositionsMagnitude = (currentPosition1 - currentPosition2).magnitude;
            var magnitudeDifference = currentPositionsMagnitude - previousPositionsMagnitude;
            if (magnitudeDifference > 0)
                _fieldOfView -= 1;
            else if (magnitudeDifference < 0) _fieldOfView += 1;

            _fieldOfView = Mathf.Clamp(_fieldOfView, cameraConfigs.fieldOfView.min, cameraConfigs.fieldOfView.max);
            cam.fieldOfView = _fieldOfView;
        }

        protected void TranslateY(float deltaY)
        {
            var currentCameraPosition = transform.position;
            var newCameraYPosition =
                currentCameraPosition.y - deltaY * cameraConfigs.speedModifier.translation;
            currentCameraPosition.y =
                Mathf.Clamp(newCameraYPosition, cameraConfigs.height.min, cameraConfigs.height.max);
            currentCameraPosition.z = startingZEulerAngle;
            transform.position = currentCameraPosition;
        }

        protected abstract void Scroll(Vector2 deltaPosition);

        protected static float ClampInAngles(float value, float min, float max)
        {
            //360°-max is closer to min then max
            if (value < (double)min || value > 360 - max)
                value = min;
            else if (value > (double)max)
                value = max;
            return value;
        }
    }
}