using Assets.UnityComponentSystem.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.Movement
{
    public class PathDebug : MonoBehaviour
    {
        private List<Vector3> _pathHolder;

        // Start is called before the first frame update
        void Start()
        {
            _pathHolder = GameManager.GetMapManager().GetPath();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            if (_pathHolder.Count == 0)
            {
                return;
            }
            Vector3 startPosition = _pathHolder[0];
            Vector3 previousPosition = startPosition;

            foreach (Vector3 wayPoint in _pathHolder)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(wayPoint, 0.3f);
                Gizmos.DrawLine(previousPosition, wayPoint);
                previousPosition = wayPoint;
            }
            Gizmos.DrawLine(previousPosition, startPosition);


        }
    }
}

