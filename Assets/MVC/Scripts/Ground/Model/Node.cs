using UnityEngine;
namespace Assets.MVC.Scripts.Ground.Model
{
    public enum NodeType
    {
        Passable,
        Impassable,
        Start,
        Finish,
        None
    }

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

    public class Node : MonoBehaviour
    {
        public NodeType Type;
        public Point Point;
        public Node Parent;
    }
}
