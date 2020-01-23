using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                var ground = hitInfo.transform.gameObject.GetComponent<Ground>();

                if (ground != null)
                {
                    var movement = GetComponent<IMovement>();

                    if (movement != null)
                    {
                        if (Physics.Linecast(transform.position, hitInfo.point, out var obstacleHitInfo, LayerMask.GetMask("Obstacle")))
                        {
                            var direction = (transform.position - obstacleHitInfo.point).normalized;
                            movement.SetTarget(obstacleHitInfo.point + direction / 2);
                        }
                        else
                        {
                            movement.SetTarget(hitInfo.point);
                        }
                    }

                    var rotation = GetComponent<IRotation>();
                    if (rotation != null)
                    {
                        rotation.SetTarget(hitInfo.point);
                    }
                }
            }
        }
    }
}
    

    

