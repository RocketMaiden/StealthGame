
using Assets.MVC.Scripts.MapObject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
{
    public struct GuardModel : IGuardModel
    {       
        public static GuardModel Create()
        {
            var model = new GuardModel(Vector3.zero, Quaternion.identity);            
            return model;
        }
        public Guid Guid { get; private set; }

        public MapObjectType MapObjectType { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }
        public List<Vector3> PatrolPath { get; set; }
        public int CurrentNode { get; set; }
        public float VisionLength { get; set; }
        public float VisionAngle { get; set; }
        public float PlayerVisibleTimer { get; set; }
        public Color Color { get; set; }

        public GuardModel(Vector3 position, Quaternion rotation)
        {
            Guid = Guid.NewGuid();
            MapObjectType = MapObjectType.Guard;
            Position = position;
            TargetPosition = position;
            Rotation = rotation;

            PatrolPath = new List<Vector3>();
            CurrentNode = 0;
            VisionAngle = 0;
            VisionLength = 0;
            PlayerVisibleTimer = 0;
            Color = new Color();
        }


    }
}

