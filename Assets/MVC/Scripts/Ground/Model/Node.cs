using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Player.View;
using UnityEditor;
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

    public class Node : MonoBehaviour
    {
        public NodeType Type;
        public int PathValue;

        public bool NodeIsTouched;

        public Point Point;        

        private void OnTriggerEnter(Collider other)
        {            
            if (Type == NodeType.Finish && other.gameObject.GetComponent<PlayerView>())
            {
                NodeIsTouched = true;
            }
        }

        void OnDrawGizmos()
        {
            Handles.Label(transform.position, PathValue.ToString());
        }


    }
}
