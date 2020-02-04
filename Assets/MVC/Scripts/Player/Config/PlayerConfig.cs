using UnityEngine;

namespace Assets.MVC.Scripts.Player.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/CreatePlayerConfig", order = 2)]
    public class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [SerializeField]
        private Vector3 _position = default;
        public Vector3 Position => _position;
        [SerializeField]
        private Vector3 _targetPosition = default;
        public Vector3 TargetPosition => _targetPosition;
        [SerializeField]
        private Quaternion _rotation = default;
        public Quaternion Rotation => _rotation;
        [SerializeField]
        private float _playerVisibleTimer = default;
        public float PlayerVisibleTimer => _playerVisibleTimer;
        [SerializeField]
        private float _timeToSpotPlayer = default;
        public float TimeToSpotPlayer => _timeToSpotPlayer;  
    }
}
