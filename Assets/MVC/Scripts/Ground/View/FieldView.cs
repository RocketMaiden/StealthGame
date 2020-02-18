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
        [SerializeField]
        private GameObject ExitNodePrefab = null;
        [SerializeField]
        private GameObject PlayerSpawnPositionPrefab = null;

        public Node CreatePassableNode(Vector3 position)
        {
            var go = Instantiate(PassableNodePrefab, position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            var node = go.GetComponent<Node>();
            return node;
        }
        public Node CreateImpassableNode(Vector3 position)
        {
            var go = Instantiate(ImpassableNodePrefab, position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            var node = go.GetComponent<Node>();
            return node;
        }
        public Node CreateExit(Vector3 position)
        {
            var go = Instantiate(ExitNodePrefab, position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            var node = go.GetComponent<Node>();
            return node;
        }
        public Node SpawnPlayer(Vector3 position)
        {
            var go = Instantiate(PlayerSpawnPositionPrefab, position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            var node = go.GetComponent<Node>();
            return node;
        }
    }
}
