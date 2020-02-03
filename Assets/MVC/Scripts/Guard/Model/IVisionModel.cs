using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
    
{
    public interface IVisionModel
    {
        float VisionLength { get; set; }
        float VisionAngle { get; set; }       

        Color Color { get; set; }
    }
}
