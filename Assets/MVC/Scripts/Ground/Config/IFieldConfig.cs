using System.Collections.Generic;

namespace Assets.MVC.Scripts.Ground.Config
{

    public interface IFieldConfig
    {
        List<CellConfig> Field { get; }
        int Width { get; }
        int Height { get; }
    }
}
