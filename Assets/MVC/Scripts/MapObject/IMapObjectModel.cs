using UnityEngine;

namespace Assets.MVC.Scripts.MapObject
{
    public interface IMapObjectModel
    {
        Vector3 Position { get; set; }
        Vector3 TargetPosition { get; set; }
        Quaternion Rotation { get; set; }
    }
}
