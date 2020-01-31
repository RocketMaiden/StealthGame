using UnityEngine;

namespace Assets.MVC.Scripts.Guard.View
{
    public interface IGuardView
    {
        void SetPosition(Vector3 position);

        void SetRotation(Quaternion rotation);

        void SetLightColor(Color color);

        void SetLightSettings(float visionLength, float visionAngle);

    }
}
