using Assets.UnityComponentSystem.Scripts.Managers;
using Assets.UnityComponentSystem.Scripts.Movement;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        targetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {       

        var movement = GetComponent<IMovement>();      
        
        var path = GameManager.GetMapManager().GetPath();

        if (movement != null)
        {
            if (movement.IsComplete())
            {
                targetIndex++;
                if (targetIndex >= path.Count)
                {
                    targetIndex = 0;
                }
                var target = path[targetIndex];
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
