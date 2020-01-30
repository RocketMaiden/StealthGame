using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
{
    public interface IGuardPatrolModel
    {
        List<Vector3> PatrolPath { get; set; }
        int CurrentNode { get; set; }
    }
}
