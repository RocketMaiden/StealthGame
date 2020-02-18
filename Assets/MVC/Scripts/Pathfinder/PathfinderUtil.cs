using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;
using System.Collections.Generic;

namespace Assets.MVC.Scripts.Pathfinder
{
    public static class PathfinderUtil
    {
        public static List<Point> GetPath(Point start, Point target)
        {
            FieldModel model = FieldStorage.GetField();


            return new List<Point>() {target };
        }
    }
}
