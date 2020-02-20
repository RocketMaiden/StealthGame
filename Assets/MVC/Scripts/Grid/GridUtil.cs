using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Grid
{
    [Serializable]
    public struct Point
    {
        public int X;
        public int Z;

        public Point(int x, int y)
        {
            X = x;
            Z = y;
        }
    }
    public static class GridUtil
    {
        public static Point ConvertToGrid(Vector3 currentPosition)
        {
            Point gridPosition;
            int gridStep = 1;
            gridPosition.X = Mathf.FloorToInt(currentPosition.x / gridStep);
            gridPosition.Z = Mathf.FloorToInt(currentPosition.z / gridStep);
            return gridPosition;
        }

        public static List<Point> ConvertPathToGrid(List<Vector3> path)
        {
            List<Point> pointList = new List<Point>();
            foreach(Vector3 position in path)
            {
                pointList.Add(ConvertToGrid(position));
            }
            return pointList;
        }

        public static Vector3 ConvertPointToPosition(Point point)
        {
            return new Vector3(point.X, 0f, point.Z);
        }
    }
}
