

using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Config
{
    public interface IGuardConfig
    {
        List<Vector3> PatrolPath { get; }
        int CurrentNode { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get;  }
        float VisionLength { get;  }
        float VisionAngle { get;  }
        LayerMask LayerMask { get; }
    }
}
