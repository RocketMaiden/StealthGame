using UnityEngine;

namespace Assets.MVC.Scripts.Player.View
{
    public interface IPlayerView 
    {
        void SetPosition(Vector3 position);

        void SetRotation(Quaternion rotation);

    }
}
