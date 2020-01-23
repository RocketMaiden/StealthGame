using UnityEngine;

public class MoveTowards : MonoBehaviour, IMovement
{
    public float Speed;

    private Vector3 _target;

    private void Start()
    {


    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Speed * Time.deltaTime);
    }

    public bool IsComplete()
    {
        return (Vector3.Distance(transform.position, _target) < 0.2f);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
