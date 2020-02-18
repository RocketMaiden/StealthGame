using Assets.MVC.Scripts.Grid;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.Model
{
    public class FieldStorage
    {
        private static FieldModel _field;       

        public static void UpdateField(FieldModel fieldModel)
        {
            _field = fieldModel;
        }

        public static FieldModel GetField()
        {
            return _field;
        }

        public static Point GetPlayerSpawn()
        {
            Point point = new Point();
            foreach (var node in _field.Field)
            {
                if (node.Type == NodeType.Start)
                {
                    return node.Point;
                }
            }
            Debug.LogError("NodeType.Start not found");
            return point;
        }

        public static Node GetFinishes()
        {            
            foreach (var node in _field.Field)
            {
                if (node.Type == NodeType.Finish)
                {
                    return node;
                }
            }
            Debug.LogError("NodeType.Finish not found");
            return default;
        }
    }  
}
