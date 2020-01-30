
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
{
    public struct GuardModel : IGuardModel
    {
        public Vector3 Position { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Quaternion Rotation { get; set; }
        public List<Vector3> PatrolPath { get; set; }
        public int CurrentNode { get; set; }
        public float VisionLength { get; set; }
        public float VisionAngle { get; set; }
        public float PlayerVisibleTimer { get; set; }
        public Color Color { get; set; }      
    }
}

