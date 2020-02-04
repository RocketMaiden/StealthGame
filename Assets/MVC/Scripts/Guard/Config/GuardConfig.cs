
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Config
{
    [CreateAssetMenu(fileName = "GuardConfig", menuName = "Configs/CreateGuardConfig", order = 1)]
    public class GuardConfig : ScriptableObject, IGuardConfig
    {
        [SerializeField]
        private List<Vector3> _patrolPath = default;
        public List<Vector3> PatrolPath => _patrolPath;

        [SerializeField]
        private int _currentNode = default;
        public int CurrentNode { get { return _currentNode; } }

        [SerializeField]
        private Vector3 _position = default;
        public Vector3 Position => _position;

        [SerializeField]
        private Quaternion _rotation = default;
        public Quaternion Rotation => _rotation;

        [SerializeField]
        private float _visionLength = default;
        public float VisionLength => _visionLength;

        [SerializeField]
        private float _visionAngle = default;
        public float VisionAngle => _visionAngle;

        [SerializeField]
        private LayerMask _layerMask = default;
        public LayerMask LayerMask => _layerMask;
    }
}
