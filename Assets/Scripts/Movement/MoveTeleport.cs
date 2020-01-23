
using UnityEngine;

public class MoveTeleport : MonoBehaviour, IMovement
{
    public Vector3 Target;

    float time;
   
    private void Start()
    {


    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            transform.position = Target;
            time = 0;
        }
    }

    public bool IsComplete()
    {
        return (Vector3.Distance(transform.position, Target) < 1.0f);
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }
}
