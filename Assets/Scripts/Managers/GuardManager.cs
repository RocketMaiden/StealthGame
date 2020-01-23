using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject guardPrefab;

    private GameObject _guard;

    private void Start()
    {
        _guard = Instantiate(guardPrefab);
        _guard.transform.SetParent(this.transform);
    }

    public void UpdateVisibilityOfPlayer(float visability)
    {
        if (Mathf.Approximately(visability, 1))
        {
            GameManager.GetGameManager().GetPlayer().DisableTarget();
            GameManager.GetGameManager().GetUI().ShowGameLoseUI();
        }
    }

    public Vector3 GetTargetPosition()
    {
        return GameManager.GetGameManager().GetPlayer().GetCurrentPosition();
    }
}
