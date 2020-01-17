using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                var movement = GetComponent<IMovement>();

                if (movement != null)
                {
                    movement.SetTarget(hitInfo.point);
                }

                var rotation = GetComponent<IRotation>();
                if(rotation!= null)
                {
                    rotation.SetTarget(hitInfo.point);
                }
            }


        }
    }
}
    

