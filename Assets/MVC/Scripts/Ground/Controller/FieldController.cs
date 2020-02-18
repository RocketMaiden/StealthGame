using UnityEngine;
using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.Ground.Config;
using Assets.MVC.Scripts.Ground.View;
using System;

namespace Assets.MVC.Scripts.Ground.Controller
{
    public class FieldController
    {

        

        public FieldController(FieldConfig config, IFieldView view)
        {
            var _fieldModel = new FieldModel(config);            

            foreach (var fieldCell in config._field)
            {
                Node node = null;
                switch (fieldCell.CellType)
                {
                    case FieldConfigEnum.Floor:
                        node = view.CreatePassableNode(new Vector3(fieldCell.X, 0, fieldCell.Y));
                        break;
                    case FieldConfigEnum.Spawn:
                        node = view.SpawnPlayer(new Vector3(fieldCell.X, 0, fieldCell.Y));
                        break;
                    case FieldConfigEnum.Wall:
                        node = view.CreateImpassableNode(new Vector3(fieldCell.X, 0, fieldCell.Y));
                        break;
                    case FieldConfigEnum.Exit:
                        node = view.CreateExit(new Vector3(fieldCell.X, 0, fieldCell.Y));
                        break;
                    default:
                        Debug.LogError("invalid node type");
                        break;
                }                
                node.Point.X = fieldCell.X;
                node.Point.Z = fieldCell.Y;
                _fieldModel.AddNode(node);                
            }

            FieldStorage.UpdateField(_fieldModel);
        }

        public void ClearField()
        {
            var _fieldModel = FieldStorage.GetField();
            for (int i = 0; i < _fieldModel.Width; i++)
            {
                for (int j = 0; j < _fieldModel.Height; j++)
                {
                    _fieldModel.Field[i, j].Parent = null;
                }
            }
        }

        public void Tick()
        {
            
        }
    }
}
