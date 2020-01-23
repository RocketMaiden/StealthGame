using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private GameObject _player;

    private void Start()
    {
        _player = Instantiate(playerPrefab);
        _player.transform.SetParent(this.transform);

    }

    public void DisableTarget()
    {
        _player.GetComponent<PlayerMovement>().enabled = false;
        _player.GetComponent<IMovement>().enabled = false;
    }

    public bool IsItPlayer(GameObject other)
    {
        var player = other.GetComponent<PlayerMovement>();
        return player != null;
    }

    public Vector3 GetCurrentPosition()
    {
        return _player.transform.position;
    }
}
