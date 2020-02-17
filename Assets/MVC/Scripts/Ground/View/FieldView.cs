using Assets.MVC.Scripts.Ground.Model;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.View
{
    public class FieldView : MonoBehaviour, IFieldView
    {
        [SerializeField]
        private GameObject PassableNodePrefab = null;
        [SerializeField]
        private GameObject ImpassableNodePrefab = null;

        public Node CreatePassableNode(Vector3 position)
        {
            var go = Instantiate(PassableNodePrefab, position, Quaternion.identity);
            var node = go.GetComponent<Node>();
            return node;
        }
        public Node CreateImpassableNode(Vector3 position)
        {
            var go = Instantiate(ImpassableNodePrefab, position, Quaternion.identity);
            var node = go.GetComponent<Node>();
            return node;
        }

    }
}
