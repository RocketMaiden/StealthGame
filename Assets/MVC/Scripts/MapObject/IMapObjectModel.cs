using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.MapObject
{   
    public interface IMapObjectModel
    {
        Guid Guid { get; }
        NodeType NodeType { get; }
        Vector3 Position { get; set; }
        Point GridPosition { get; set; }
        Quaternion Rotation { get; set; }
    }

    public interface IMapMovableModel : IMapObjectModel
    {
        Vector3 TargetPosition { get; set; }
        Point GridTargetPosition { get; set; }
        List <Point> Path { get; set; }
        int CurrentNode { get; set; }
    }
}
