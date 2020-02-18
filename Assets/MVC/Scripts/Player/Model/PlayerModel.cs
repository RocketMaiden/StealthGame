using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.Player.Config;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.MVC.Scripts.Player.Model
{
    public struct PlayerModel : IPlayerModel
    {
        public Guid Guid { get; private set; }
        public NodeType NodeType { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }

        public Point GridTargetPosition { get; set; }
        public Point GridPosition { get; set; }

        public List <Point> Path { get; set; }

        public float PlayerVisibleTimer { get; set; }
        public float TimeToSpotPlayer { get; set; }
        public bool IsSpotted { get; set; }
        public int CurrentNode { get; set; }

        public PlayerModel(IPlayerConfig config)
        {
            Guid = Guid.NewGuid();
            NodeType = NodeType.Player;
            IsSpotted = false;

            Position = config.Position;
            TargetPosition = config.TargetPosition;
            Rotation = config.Rotation;
            PlayerVisibleTimer = config.PlayerVisibleTimer;
            TimeToSpotPlayer = config.TimeToSpotPlayer;

            GridPosition = GridUtil.ConvertToGrid(config.Position);
            GridTargetPosition = GridUtil.ConvertToGrid(config.TargetPosition);

            Path = new List<Point>();
            CurrentNode = 0;

        }

    }
}
