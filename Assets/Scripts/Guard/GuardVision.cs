using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuardVision : MonoBehaviour
{    
    public float TimeToSpotPLayer;

    private float _playerVisibleTimer;
   
    private Vector3 _target;

    [SerializeField]
    private float _viewDistance = 10.0f;
    [SerializeField]
    private float _viewAngle = 45.0f;
    [SerializeField]
    private LayerMask _layerMask = default;

    private float _visability;


    // Update is called once per frame
    void Update()
    {
        _target = GameManager.GetGameManager().GetGuard().GetTargetPosition();

        var canSeeTarget = GetComponent<VisionOfTarget>().CanSeeTarget(_target, _viewDistance, _viewAngle, _layerMask);
        
        if (canSeeTarget)
        {            
            _playerVisibleTimer += Time.deltaTime;
        }
        else
        {            
            _playerVisibleTimer -= Time.deltaTime;
        }
        _playerVisibleTimer = Mathf.Clamp(_playerVisibleTimer, 0, TimeToSpotPLayer);
        _visability = _playerVisibleTimer / TimeToSpotPLayer;

         GameManager.GetGameManager().GetGuard().UpdateVisibilityOfPlayer(_visability);
    }
    public float GetTargetVisiblity()
    {
        return _visability;
    }
    


}
