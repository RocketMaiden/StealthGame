using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightColorUpdater : MonoBehaviour
{
    [SerializeField]
    private Light _spotLight;

    private Color _originalSpotLightColor;

    void Start()
    {
        
        _originalSpotLightColor = _spotLight.color;
        GetComponent<AIVision>().OnGuardHasSpottedPlayer += UpdateColor;
    }

    private void UpdateColor(float visability)
    {
        _spotLight.color = Color.Lerp(_originalSpotLightColor, Color.red, visability);
    }

    void OnDestroy()
    {
        GetComponent<AIVision>().OnGuardHasSpottedPlayer -= UpdateColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
