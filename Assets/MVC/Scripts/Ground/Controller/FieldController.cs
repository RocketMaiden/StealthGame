using UnityEngine;
using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.Ground.Config;
using Assets.MVC.Scripts.Ground.View;
using System;

namespace Assets.MVC.Scripts.Ground.Controller
{
    public class FieldController
    {

        private FieldModel _fieldModel;



        public FieldController(FieldConfig config, IFieldView view)
        {
            _fieldModel = new FieldModel(config);            

            foreach (var fieldCell in config._field)
            {
                if (fieldCell.CellType == FieldConfigEnum.Passable)
                {
                    var node = view.CreatePassableNode(new Vector3(fieldCell.X, 0, fieldCell.Y));
                    _fieldModel.AddNode(node);

                }
                if (fieldCell.CellType == FieldConfigEnum.Impassable)
                {
                    var node = view.CreateImpassableNode(new Vector3(fieldCell.X, 0, fieldCell.Y));
                    _fieldModel.AddNode(node);

                }
            }

            //foreach (var fieldCell in config._field)
            //{
            //    if (fieldCell == FieldConfigEnum.Passable)
            //    {
            //        int y = config._field.Count / config._height;
            //        int x = config._field.Count - config._height* 
            //        var node = view.CreatePassableNode(new Vector3(x, 0, y));
            //        _fieldModel.AddNode(node);
            //        _fieldModel.AddNode(fieldCell.)
            //    }
            //}

            //for (int y = 0; y < _fieldModel.Height; y++)
            //{
            //    for (int x = 0; x < _fieldModel.Width; x++)
            //    {
            //        if(config.Field[x,y] == FieldConfigEnum.Passable)
            //        {
            //            var node = view.CreatePassableNode(new Vector3(x, 0, y));
            //            _fieldModel.AddNode(node);

            //        }
            //    }
            //}
            //var mapParent = new GameObject("Map");
            //_fieldModel = new FieldModel(config);
            //for (int i = 0; i < _fieldModel.Width; i++)
            //{
            //    for (int j = 0; j < _fieldModel.Height; j++)
            //    {
            //        var go = GameObject.Instantiate(_nodePrefab, new Vector3(i, -1.0f, j), Quaternion.identity);
            //        go.transform.SetParent(mapParent.transform);
            //        Node currentNode = go.GetComponent<Node>();
            //        currentNode.Point.X = i;
            //        currentNode.Point.Y = j;
            //        currentNode.Type = NodeType.Passable;
            //        _fieldModel.AddNode(currentNode);
            //    }
            //}
        }

        public void ClearField()
        {
            for (int i = 0; i < _fieldModel.Width; i++)
            {
                for (int j = 0; j < _fieldModel.Height; j++)
                {
                    _fieldModel.Field[i, j].Parent = null;
                }
            }
        }

        internal void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
