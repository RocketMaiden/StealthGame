using Assets.MVC.Scripts.Ground.Model;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.MapObject
{
    public enum MapObjectType
    {
        None,
        Player,
        Guard,
        //todo: revove node relative types
        Wall,
        Finish
    }
    public interface IMapObjectModel
    {
        Guid Guid { get; }
        MapObjectType MapObjectType { get; }
        Vector3 Position { get; set; }
        Point GridPosition { get; set; }
        Quaternion Rotation { get; set; }
    }

    public interface IMapMovableModel : IMapObjectModel
    {
        Vector3 TargetPosition { get; set; }
        Point GridTargetPosition { get; set; }
    }
}
