using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.Guard
{
    public class VisionOfTarget : MonoBehaviour
    {
        public bool CanSeeTarget(Vector3 target, float viewDistance, float viewAngle, LayerMask mask)
        {
            float viewDistanceSq = viewDistance * viewDistance;
            Vector3 offset = target - transform.position;
            float sqrDistance = offset.sqrMagnitude;
            if (sqrDistance < viewDistanceSq)
            {
                Vector3 directionToTarget = offset.normalized;
                float angleBetweenMeAndTarget = Vector3.Angle(transform.forward, directionToTarget);
                if (angleBetweenMeAndTarget < viewAngle / 2)
                {
                    if (!Physics.Linecast(transform.position, target, mask))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}
