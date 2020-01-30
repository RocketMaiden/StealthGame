using UnityEngine;


namespace Assets.MVC.Scripts.Player.Model
{
    public struct PlayerModel : IPlayerModel
    {
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }
    }
}
