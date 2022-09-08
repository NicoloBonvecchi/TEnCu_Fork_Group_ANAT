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

        protected void Zoom(float deltaZoom)
        {

            //PREVIOUS CODE
            /*if (deltaZoom > 0)
                _fieldOfView -= 1;
            else if (deltaZoom < 0) _fieldOfView += 1;*/

            if (deltaZoom > 0)
                _fieldOfView -= cameraConfigs.speedModifier.zoom;
            else if (deltaZoom < 0) _fieldOfView += cameraConfigs.speedModifier.zoom;

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