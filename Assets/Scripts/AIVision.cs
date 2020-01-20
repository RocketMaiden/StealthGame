using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIVision : MonoBehaviour
{

    public GameObject WhoToFollow;
    public float TimeToSpotPLayer;

    public event Action<float> OnGuardHasSpottedPlayer;

    private float _playerVisibleTimer;
   
    private Vector3 _target;

    [SerializeField]
    private float _viewDistance;
    [SerializeField]
    private float _viewAngle;
    [SerializeField]
    private LayerMask _layerMask;

    // Start is called before the first frame update
    void Start()
    {
        OnGuardHasSpottedPlayer += DisableTarget;
    }

    private void OnDestroy()
    {
        OnGuardHasSpottedPlayer -= DisableTarget;
    }

    // Update is called once per frame
    void Update()
    {
        _target = GetComponent<CurrentTarget>().GetTargetPosition();


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
        var visability = _playerVisibleTimer / TimeToSpotPLayer;
        

        if (OnGuardHasSpottedPlayer != null)
        {
            OnGuardHasSpottedPlayer.Invoke(visability);
        }       
    }
    private void DisableTarget(float visability)
    {
        if (Mathf.Approximately(visability, 1))
        {
            GetComponent<CurrentTarget>().GetGameObject().GetComponent<PlayerMovement>().enabled = false;
        }
    }


}
