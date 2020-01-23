using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathHolder : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _pathHolder;

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
