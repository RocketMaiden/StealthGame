using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mapPrefab;

    private GameObject _map;

    private List<Vector3> _path;


    private void Start()
    {
        _map = Instantiate(_mapPrefab);
        _map.transform.SetParent(this.transform);
        var pathHolder = _map.GetComponent<PathHolder>();
        _path = pathHolder.GetPathHolder();

    }

    public void FinishIsReached(GameObject other)
    {        
        if(GameManager.GetGameManager().GetPlayer().IsItPlayer(other))
        {
            GameManager.GetGameManager().GetUI().ShowGameWinUI();
        }
    }

    public List<Vector3> GetPath()
    {
        return _path;
    }
}
