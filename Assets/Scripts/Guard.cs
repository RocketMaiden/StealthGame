using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float speed;
    int targetIndex;

    public List<Transform> pathHolder = new List<Transform>();

    private void Start()
    {
        targetIndex = 1;
        transform.position = pathHolder[0].position;        
    }

    private void Update()
    {
        Vector3 targetWaypoint = pathHolder[targetIndex].position;
        
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

        transform.LookAt(pathHolder[targetIndex]);

        if (Vector3.Distance(transform.position, targetWaypoint) < 1.0f)
        {
            targetIndex++;
            if (targetIndex >= pathHolder.Count)
            {
                targetIndex = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(pathHolder.Count == 0)
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
