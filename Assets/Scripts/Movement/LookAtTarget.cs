using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour, IRotation
{
    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_target, transform.position);
        if (distance > float.Epsilon)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_target - transform.position), 0.2f);
        }
    }
    public void SetTarget(Vector3 target)
    {
        _target = target;
    }


}
