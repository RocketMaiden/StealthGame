using Assets.MVC.Scripts.Ground.Model;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.View
{
    public interface IFieldView
    {
        Node CreatePassableNode(Vector3 position);
        Node CreateImpassableNode(Vector3 position);
    }
}
