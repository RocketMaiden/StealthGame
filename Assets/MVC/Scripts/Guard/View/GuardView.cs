using UnityEngine;

namespace Assets.MVC.Scripts.Guard.View
{
    public class GuardView : MonoBehaviour, IGuardView
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;

        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}
