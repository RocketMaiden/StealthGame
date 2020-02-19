using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Pathfinder
{
    public static class PathfinderUtil
    {
        private const int EmptyNode = -1;
        private const int StartNode = 0;

        private static FieldModel _model;
       
        public static List<Point> GetPath(Point start, Point target)
        {
            _model = FieldStorage.GetField();
            ClearField();

            if (!_model.IsValidNode(start) || !_model.IsValidNode(target))
            {
                Debug.LogError("Invalide node point");
                //fallback state
                return new List<Point>() { start };
            }
            
            List<Point> result = new List<Point>();

            _model.SetNodeValue(start, StartNode);            

            PreProcessField(new List<Point> { start }, StartNode);

            int currentPathValue = _model.GetNodeValue(target);
            if(currentPathValue == EmptyNode)
            {
                Debug.LogError("path not found");
                //fallback state
                return new List<Point>() { start };
            }

            var currentPathPoint = target;
            result.Add(target);
            for (var i = currentPathValue-1; i > 0; i-- )
            {   
                var surround = GetSurround(currentPathPoint, i);
                currentPathPoint = surround[0];
                result.Add(currentPathPoint);
            }

            result.Reverse();

            return result;
        }

        private static void PreProcessField(List<Point> wave, int currentValue)
        {
            List<Point> newWave = new List<Point>();
            foreach(var point in wave)
            {
                if (!_model.IsValidNode(point))
                {
                    continue;
                }
                
                _model.SetNodeValue(point, currentValue);

                newWave.AddRange(GetSurround(point, EmptyNode));                
            }

            if(newWave.Count == 0)
            {
                return;
            }

            PreProcessField(newWave, ++currentValue);
        }

        private static List<Point> GetSurround(Point point, int validPathValue)
        {
            var result = new List<Point>();

            if(IsValidPathNode(point.X + 1, point.Z, validPathValue))
            {
                result.Add(new Point(point.X + 1, point.Z));
            }
            if (IsValidPathNode(point.X - 1, point.Z, validPathValue))
            {
                result.Add(new Point(point.X - 1, point.Z));
            }
            if (IsValidPathNode(point.X, point.Z + 1, validPathValue))
            {
                result.Add(new Point(point.X, point.Z + 1));
            }
            if (IsValidPathNode(point.X, point.Z - 1, validPathValue))
            {
                result.Add(new Point(point.X, point.Z - 1));
            }

            return result;
        }

        private static void ClearField()
        {           
            for (int x = 0; x < _model.Width; x++)
            {
                for (int z = 0; z < _model.Height; z++)
                {
                    var node = _model.GetNode(new Point(x, z));
                    node.PathValue = EmptyNode;
                    _model.SetNode(node);
                }
            }            
        }
        private static bool IsValidPathNode(int x, int y, int validPathValue)
        {
            return IsValidPathNode(new Point(x, y), validPathValue);
        }

        private static bool IsValidPathNode(Point point, int validPathValue)
        {
            if (!_model.IsValidNode(point))
            {
                return false;
            }
            var node = _model.GetNode(point);
            if(node.Type == NodeType.Impassable)
            {
                return false;
            }
            if (node.PathValue == validPathValue)
            {
                return true;
            }
            return false;
        }
    }
}
