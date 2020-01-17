using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    int targetIndex;

    public List<Transform> pathHolder = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        targetIndex = 0;        
    }

    // Update is called once per frame
    void Update()
    {       

        var movement = GetComponent<IMovement>();
        
        if (movement != null)
        {
            if (movement.IsComplete())
            {
                targetIndex++;
                if (targetIndex >= pathHolder.Count)
                {
                    targetIndex = 0;
                }
                var target = pathHolder[targetIndex].position;
                movement.SetTarget(target);
                var rotation = GetComponent<IRotation>();
                if (rotation != null)
                {
                    rotation.SetTarget(target);
                }
            }
        }
    }
}
