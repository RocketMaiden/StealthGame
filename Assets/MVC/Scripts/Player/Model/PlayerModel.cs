using Assets.MVC.Scripts.MapObject;
using System;
using UnityEngine;


namespace Assets.MVC.Scripts.Player.Model
{
    public struct PlayerModel : IPlayerModel
    {
        public static PlayerModel Create()
        {
            var model = new PlayerModel(Vector3.zero, Quaternion.identity);           
            return model;
        }

        public Guid Guid { get; private set; }
        public MapObjectType MapObjectType { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }
       
        public PlayerModel(Vector3 position, Quaternion rotation)
        {
            Guid = Guid.NewGuid();
            MapObjectType = MapObjectType.Player;
            Position = position;
            TargetPosition = position;
            Rotation = rotation;
        }

    }
}
