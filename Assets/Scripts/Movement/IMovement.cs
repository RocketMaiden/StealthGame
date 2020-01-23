using UnityEngine;

public interface IMovement
{
    bool enabled { get; set; }

    bool IsComplete();
    void SetTarget(Vector3 target);
}

