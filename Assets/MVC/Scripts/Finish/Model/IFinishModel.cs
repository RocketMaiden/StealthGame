using Assets.MVC.Scripts.MapObject;

namespace Assets.MVC.Scripts.Finish.Model
{
    public interface IFinishModel : IMapObjectModel
    {
        bool FinishIsTouched { get; set; }
    }
}
