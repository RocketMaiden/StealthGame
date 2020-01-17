using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour, IRotation
{
    public Vector3 Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Target - transform.position), 0.2f);

        //transform.LookAt(Target);
    }
    public void SetTarget(Vector3 target)
    {
        Target = target;
    }


}
