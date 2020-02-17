using System;

namespace Assets.MVC.Scripts.Ground.Config
{
    [Serializable]
    public struct CellConfig
    {
        public FieldConfigEnum CellType;
        public int X;
        public int Y;
    }
}
