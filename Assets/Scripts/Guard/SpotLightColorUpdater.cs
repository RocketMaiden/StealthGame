using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightColorUpdater : MonoBehaviour
{
    [SerializeField]
    private Light _spotLight = null;

    private Color _originalSpotLightColor;

    void Start()
    {
        
        _originalSpotLightColor = _spotLight.color;
    }
    private void Update()
    {
        var visability = GetComponent<GuardVision>().GetTargetVisiblity();
        UpdateColor(visability);
    }

    private void UpdateColor(float visability)
    {
        _spotLight.color = Color.Lerp(_originalSpotLightColor, Color.red, visability);
    }
}
