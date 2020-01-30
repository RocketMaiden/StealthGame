using UnityEngine;

namespace Assets.MVC.Scripts.Player.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
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
