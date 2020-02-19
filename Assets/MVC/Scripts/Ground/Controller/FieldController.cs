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

            foreach (var nodeConfig in config._field)
            {
                Node node = null;
                switch (nodeConfig.CellType)
                {
                    case FieldConfigEnum.Floor:
                        node = view.CreatePassableNode(new Vector3(nodeConfig.X, 0, nodeConfig.Y));
                        break;
                    case FieldConfigEnum.Spawn:
                        node = view.SpawnPlayer(new Vector3(nodeConfig.X, 0, nodeConfig.Y));
                        break;
                    case FieldConfigEnum.Wall:
                        node = view.CreateImpassableNode(new Vector3(nodeConfig.X, 0, nodeConfig.Y));
                        break;
                    case FieldConfigEnum.Exit:
                        node = view.CreateExit(new Vector3(nodeConfig.X, 0, nodeConfig.Y));
                        break;
                    default:
                        Debug.LogError("invalid node type");
                        break;
                }                
                node.Point.X = nodeConfig.X;
                node.Point.Z = nodeConfig.Y;
                _fieldModel.SetNode(node);                
            }

            FieldStorage.UpdateField(_fieldModel);
        }       

        public void Tick()
        {
            
        }
    }
}
