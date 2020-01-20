using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetGameObject;
    
    public Vector3 GetTargetPosition()
    {
        return _targetGameObject.transform.position;
    }

    public GameObject GetGameObject()
    {
        return _targetGameObject;
    }
}
