using UnityEngine;

namespace Assets.MVC.Scripts.Grid
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public static class GridUtil
    {
        public static Point ConvertToGrid(Vector3 currentPosition)
        {
            Point gridPosition;
            int gridStep = 1;
            gridPosition.X = Mathf.FloorToInt(currentPosition.x / gridStep);
            gridPosition.Y = Mathf.FloorToInt(currentPosition.y / gridStep);
            return gridPosition;
        }
    }
}
