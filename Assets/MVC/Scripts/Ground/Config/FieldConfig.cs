using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.Config
{
    [Serializable]
    [CreateAssetMenu(fileName = "FieldConfig", menuName = "Configs/CreateFieldConfig", order = 3)]
    public class FieldConfig : ScriptableObject, IFieldConfig
    {

        [SerializeField]
        public int _width = default;
        public int Width => _width;

        [SerializeField]
        public int _height = default;
        public int Height => _height;

        [SerializeField]
        public List<CellConfig> _field = default;
        public List<CellConfig> Field => _field;       

        public void UpdateField()
        {
            if (_width > 0 && _height > 0)
            {
                var count = _width * _height;
                _field = new List<CellConfig>(count);
                for(var i = 0; i < count; i++)
                {
                    _field.Add(new CellConfig());
                }

            }
        }       
    }
}
