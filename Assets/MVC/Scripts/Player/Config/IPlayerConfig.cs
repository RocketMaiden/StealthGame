using UnityEngine;

namespace Assets.MVC.Scripts.Player.Config
{
    public interface IPlayerConfig
    {        
        Vector3 Position { get; }
        Vector3 TargetPosition { get; }
        Quaternion Rotation { get; }
        float PlayerVisibleTimer { get; }
        float TimeToSpotPlayer { get; }        
    }
}
