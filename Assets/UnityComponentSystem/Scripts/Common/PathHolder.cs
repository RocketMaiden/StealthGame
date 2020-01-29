using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.UI
{
    public class PathHolder : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _pathHolder = null;

        public List<Vector3> GetPathHolder()
        {
            var result = new List<Vector3>();
            foreach (var p in _pathHolder)
            {
                result.Add(p.position);
            }
            return result;
        }
    }
}

