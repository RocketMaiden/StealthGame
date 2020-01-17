using UnityEngine;

public class MoveTowards : MonoBehaviour, IMovement
{    
    public Vector3 Target;
    public float speed;

    private void Start()
    {
        

    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    public bool IsComplete()
    {
        return (Vector3.Distance(transform.position, Target) < 0.2f);
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }
}
