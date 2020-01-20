using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDebug : MonoBehaviour
{
    public List<Transform> pathHolder = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        pathHolder = GetComponent<PathMove>().pathHolder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        if (pathHolder.Count == 0)
        {
            return;
        }
        Vector3 startPosition = pathHolder[0].position;
        Vector3 previousPosition = startPosition;

        foreach (Transform wayPoint in pathHolder)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(wayPoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, wayPoint.position);
            previousPosition = wayPoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);          


    }
}
