using Assets.MVC.Scripts.Guard.Config;
using Assets.MVC.Scripts.MapObject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
{
    public struct GuardModel : IGuardModel
    {
        public Guid Guid { get; private set; }
        public MapObjectType MapObjectType { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }
        public List<Vector3> PatrolPath { get; set; }
        public int CurrentNode { get; set; }
        public float VisionLength { get; set; }
        public float VisionAngle { get; set; }       
        public Color Color { get; set; }
        public LayerMask LayerMask { get; set; }

        public GuardModel(IGuardConfig config)
        {
            Guid = Guid.NewGuid();
            MapObjectType = MapObjectType.Guard;
           
            Color = Color.green;

            Rotation = config.Rotation;
            PatrolPath = config.PatrolPath;
            CurrentNode = config.CurrentNode;
            Position = config.Position;
            TargetPosition = config.TargetPosition;
            VisionAngle = config.VisionAngle;
            VisionLength = config.VisionLength;
            LayerMask = config.LayerMask;
        }
    }
}

