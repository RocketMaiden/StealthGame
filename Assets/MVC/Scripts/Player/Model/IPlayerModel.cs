using Assets.MVC.Scripts.MapObject;

namespace Assets.MVC.Scripts.Player.Model
{
    public interface IPlayerModel : IMapMovableModel
    {
        float PlayerVisibleTimer { get; set; }
        float TimeToSpotPlayer { get; set; }
        bool IsSpotted { get; set; }
    }
}
