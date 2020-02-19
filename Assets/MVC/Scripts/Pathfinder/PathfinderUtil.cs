using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;
using System;
using System.Collections.Generic;

namespace Assets.MVC.Scripts.Pathfinder
{
    public static class PathfinderUtil
    {
        public static List<Point> GetPath(Point start, Point target)
        {            
            List<Point> localPath = new List<Point>();
            FieldModel model = FieldStorage.GetField();

            SetNode(start, PathNodeType.Start, model);
            SetNode(target, PathNodeType.Finish, model);

            Node nodeFinish = GoFindEndNodeWithParent(start, model);
            if (nodeFinish == null)
            {
                //это ранний выход с валидными данными: в случае, если не существует пути к финишу
                //путь состоит только из старта, и запрашивающий этот путь останется стоять на своем месте и ему не нужно будет делать проверку на null
                ClearField(model);
                return new List<Point> { start };
            }
            while (true)
            {                
                localPath.Add(nodeFinish.Point);

                //parent может не существовать только у старта, тоесть мы с конца в начало пройдем по всем точками пути способом подмены 
                if (nodeFinish.Parent == null)
                {
                    break;
                }                
                nodeFinish = nodeFinish.Parent;
            }
            
            localPath.Reverse();            
            ClearField(model);
            return localPath;
        }

        private static void ClearField(FieldModel model)
        {           
            for (int x = 0; x < model.Width; x++)
            {
                for (int z = 0; z < model.Height; z++)
                {
                    var node = model.GetNode(new Point(x, z));
                    node.Parent = null;
                    if( node.PathType == PathNodeType.Start || node.PathType == PathNodeType.Finish)
                    {
                        node.PathType = PathNodeType.Passable;
                    }
                    model.SetNode(node);
                }
            }            
        }


        private static void SetNode(Point point, PathNodeType type, FieldModel model)
        {           
            Node selectedNode = model.GetNode(point);
            selectedNode.PathType = type;
            model.SetNode(selectedNode);            
        }
        private static Node GoFindEndNodeWithParent(Point current, FieldModel model)
        {            
            List<Point> _surroundPoints = new List<Point>();

            Point rightNeighbour = new Point();
            rightNeighbour.X = current.X;
            rightNeighbour.Z = current.Z + 1;

            if (IsItSurround(rightNeighbour, current, model))
            {
                Node rightNeighbourNode = model.GetNode(rightNeighbour);
                if (rightNeighbourNode.PathType == PathNodeType.Finish)
                {
                    //if we find end we return endNode with its already filled parent info
                    return rightNeighbourNode;
                }
                _surroundPoints.Add(rightNeighbour);
            }

            //check next neighbour
            Point leftNeighbour = new Point();
            leftNeighbour.X = current.X;
            leftNeighbour.Z = current.Z - 1;

            if (IsItSurround(leftNeighbour, current, model))
            {
                Node leftNeighbourNode = model.GetNode(leftNeighbour);
                if (leftNeighbourNode.PathType == PathNodeType.Finish)
                {
                    //if we find end we return endNode with its already filled parent info
                    return leftNeighbourNode;
                }
                _surroundPoints.Add(leftNeighbour);
            }

            //check next neighbour
            Point upNeighbour = new Point();
            upNeighbour.X = current.X - 1;
            upNeighbour.Z = current.Z;

            if (IsItSurround(upNeighbour, current, model))
            {
                Node upNeighbourNode = model.GetNode(upNeighbour);
                if (upNeighbourNode.PathType == PathNodeType.Finish)
                {
                    //if we find end we return endNode with its already filled parent info
                    return upNeighbourNode;
                }
                _surroundPoints.Add(upNeighbour);
            }

            //check next neighbour
            Point downNeighbour = new Point();
            downNeighbour.X = current.X + 1;
            downNeighbour.Z = current.Z;

            if (IsItSurround(downNeighbour, current, model))
            {
                Node downNeighbourNode = model.GetNode(downNeighbour);
                if (downNeighbourNode.PathType == PathNodeType.Finish)
                {
                    //if we find end we return endNode with its already filled parent info
                    return downNeighbourNode;
                }
                _surroundPoints.Add(downNeighbour);
            }

            //recursively check nodes for endNode from selected previously
            for (int index = 0; index < _surroundPoints.Count; index++)
            {
                Node node = GoFindEndNodeWithParent(_surroundPoints[index], model);
                if (node != null)
                {
                    return node;
                }
            }

            return null;
        }
        private static bool IsItSurround(Point point, Point current, FieldModel model)
        {            
            if (IsPointValid(point, model))
            {
                Node testedNode = model.GetNode(point);
                Node currentNode = model.GetNode(current);
                testedNode.Parent = currentNode;
                model.SetNode(testedNode);                
                return true;
            }
            return false;
        }
        private static bool IsPointValid(Point point, FieldModel model)
        {            

            if (point.X < 0 || point.X >= model.Width ||
                point.Z < 0 || point.Z >= model.Height)
            {
                return false;
            }
            if (model.Field[point.X, point.Z].PathType == PathNodeType.Impassable || model.Field[point.X, point.Z].PathType == PathNodeType.Start)
            {
                return false;
            }
            if (model.Field[point.X, point.Z].Parent != null)
            {
                return false;
            }
            return true;
        }
    }
}
