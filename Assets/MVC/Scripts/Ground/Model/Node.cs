using Assets.MVC.Scripts.Grid;
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

    public class Node : MonoBehaviour
    {
        public NodeType Type;
        public Point Point;
        public Node Parent;
    }
}
