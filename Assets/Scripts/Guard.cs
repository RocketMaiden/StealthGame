using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float speed;
    public Transform Player;
    public Light SpotLight;
    public float viewDistance;
    public List<Transform> pathHolder = new List<Transform>();
    public LayerMask viewMask;
    public float TimeToSpotPLayer = 0.5f;

    public static event System.Action OnGuardHasSpottedPlayer;

    private int targetIndex;    
    private float viewAngle;
    private float playerVisibleTimer;
    private Color originalSpotLightColor;
    

    private void Start()
    {
        targetIndex = 1;
        transform.position = pathHolder[0].position;
        viewAngle = SpotLight.spotAngle;
        viewDistance = SpotLight.range;
        originalSpotLightColor = SpotLight.color;

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

        if (CanSeePlayer())
        {
            SpotLight.color = Color.red;
            playerVisibleTimer += Time.deltaTime;
            Debug.Log("guard can see the player");
        }
        else
        {
            SpotLight.color = originalSpotLightColor;
            playerVisibleTimer -= Time.deltaTime;
        }
        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, TimeToSpotPLayer);
        SpotLight.color = Color.Lerp(originalSpotLightColor, Color.red, playerVisibleTimer / TimeToSpotPLayer);

        if (playerVisibleTimer >= TimeToSpotPLayer)
        {
            if (OnGuardHasSpottedPlayer != null)
            {
                OnGuardHasSpottedPlayer();
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

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);


    }

    bool CanSeePlayer()
    {
        float viewDistanceSq = viewDistance * viewDistance;
        Vector3 offset = Player.position - transform.position;
        float sqrDistance = offset.sqrMagnitude;
        if (sqrDistance < viewDistanceSq)
        {
            Vector3 directionToPlayer = offset.normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2)
            {
                if (!Physics.Linecast(transform.position, Player.position, viewMask))
                {                    
                    return true;                    
                }
            }
        }
        return false;
    }

    





}
