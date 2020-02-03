using Assets.MVC.Scripts.MapObject;
using System;
using UnityEngine;


namespace Assets.MVC.Scripts.Player.Model
{
    public struct PlayerModel : IPlayerModel
    {
        public Guid Guid { get; private set; }
        public MapObjectType MapObjectType { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }

        public float PlayerVisibleTimer { get; set; }
        public float TimeToSpotPlayer { get; set; }

        public bool IsSpotted { get; set; }

        public PlayerModel(Vector3 position, Quaternion rotation)
        {
            Guid = Guid.NewGuid();
            MapObjectType = MapObjectType.Player;

            Position = position;
            TargetPosition = position;
            Rotation = rotation;

            PlayerVisibleTimer = 0;
            TimeToSpotPlayer = 0;
            IsSpotted = false;
        }

    }
}
