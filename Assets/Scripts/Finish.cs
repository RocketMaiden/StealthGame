using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    public event Action FinishIsTouched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerMovement>();
        if (player!= null)
        {
            if (FinishIsTouched != null)
            {
                FinishIsTouched.Invoke();
            }
        }
    }
}
