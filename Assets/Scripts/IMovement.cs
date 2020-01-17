using UnityEngine;

public interface IMovement
{
    bool IsComplete();
    void SetTarget(Vector3 target);
}

