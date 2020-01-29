using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.Movement
{
    public interface IMovement
    {
        bool enabled { get; set; }

        bool IsComplete();
        void SetTarget(Vector3 target);
    }
}
   



