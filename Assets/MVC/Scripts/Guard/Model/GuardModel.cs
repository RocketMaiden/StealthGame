using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.Guard.Config;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
{
    public struct GuardModel : IGuardModel
    {
        public Guid Guid { get; private set; }       
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }
        public List<Point> Path { get; set; }
        public int CurrentNode { get; set; }
        public float VisionLength { get; set; }
        public float VisionAngle { get; set; }       
        public Color Color { get; set; }
        public LayerMask LayerMask { get; set; }
        public Point GridTargetPosition { get; set; }
        public Point GridPosition { get; set; }
        public NodeType NodeType { get; private set; }

        public GuardModel(IGuardConfig config)
        {
            Guid = Guid.NewGuid();
            NodeType = NodeType.Guard;
           
            Color = Color.green;

            Rotation = config.Rotation;
            Path = GridUtil.ConvertPathToGrid(config.PatrolPath);
            CurrentNode = config.CurrentNode;
            Position = config.Position;
            TargetPosition = config.TargetPosition;
            VisionAngle = config.VisionAngle;
            VisionLength = config.VisionLength;
            LayerMask = config.LayerMask;

            GridPosition = GridUtil.ConvertToGrid(Position);
            GridTargetPosition = GridUtil.ConvertToGrid(TargetPosition);
               
        }
    }
}

