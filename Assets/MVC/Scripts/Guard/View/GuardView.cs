using UnityEngine;

namespace Assets.MVC.Scripts.Guard.View
{
    public class GuardView : MonoBehaviour, IGuardView
    {
        [SerializeField]
        private Light _spotLight = null;



        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public void SetLightColor(Color color)
        {
            _spotLight.color = color;           
        }

        public void SetLightSettings(float visionLength, float visionAngle)
        {            
            _spotLight.range = visionLength;
            _spotLight.spotAngle = visionAngle;
        }
    }
}

