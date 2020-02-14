using UnityEngine;
using Assets.MVC.Scripts.Ground.Model;


namespace Assets.MVC.Scripts.Ground.Controller
{
    public class FieldController
    {

        private FieldModel _fieldModel;
        
        public FieldController(GameObject _nodePrefab)
        {
            var mapParent = new GameObject("Map");
            _fieldModel = new FieldModel(4, 5);
            for (int i = 0; i < _fieldModel.Width; i++)
            {
                for (int j = 0; j < _fieldModel.Height; j++)
                {
                    var go = GameObject.Instantiate(_nodePrefab, new Vector3(i, -1.0f, j), Quaternion.identity);
                    go.transform.SetParent(mapParent.transform);
                    Node currentNode = go.GetComponent<Node>();
                    currentNode.Point.X = i;
                    currentNode.Point.Y = j;
                    currentNode.Type = NodeType.Passable;
                    _fieldModel.AddNode(currentNode);
                }
            }
        }

        public void ClearField()
        {
            for (int i = 0; i < _fieldModel.Width; i++)
            {
                for (int j = 0; j < _fieldModel.Height; j++)
                {
                    _fieldModel.Field[i, j].Parent = null;
                }
            }
        }        
    }
}
