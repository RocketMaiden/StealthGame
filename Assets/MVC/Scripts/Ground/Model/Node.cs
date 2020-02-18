using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Player.View;
using UnityEngine;
namespace Assets.MVC.Scripts.Ground.Model
{
    public enum NodeType
    {
        Passable,
        Impassable,
        Start,
        Finish,
        Player,
        Guard,
        None
    }

    //for pathfinder
    public enum PathNodeType
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
        public Node Parent;

        public bool NodeIsTouched;

        public Point Point;
        public PathNodeType PathType;

        private void OnTriggerEnter(Collider other)
        {            
            if (Type == NodeType.Finish && other.gameObject.GetComponent<PlayerView>())
            {
                NodeIsTouched = true;
            }
        }


    }
}
