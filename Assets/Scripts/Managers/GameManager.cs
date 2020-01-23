using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static part of game manager
    private static GameManager myGameManager;
    private static bool _initialized;
    public static GameManager GetGameManager()
    {
        if (!_initialized) 
        {
            Debug.LogException(new Exception("[game manager] not initialized"));
        }

        if(myGameManager == null)
        {
            Debug.LogException(new Exception("[game manager] not found"));
        }

        return myGameManager;
    }

    public static MapManager GetMapManager()
    {
        return myGameManager.GetMap();
    }


    //normal monobehaviour part of game manager
    [SerializeField]
    MapManager _mapManager;

    [SerializeField]
    PlayerManager _playerManager;

    [SerializeField]
    GuardManager _guardManager;

    [SerializeField]
    GameUIManager _gameUIManager;

    private void Awake()
    {
        if (myGameManager != null && myGameManager != this)
        {
            Debug.LogException(new Exception("[game manager] already exists"));
            Destroy(this);            
        }
        else
        {
            myGameManager = this;
            _initialized = true;
            Debug.Log(new Exception("[game manager] initialized"));
        }
    }

    public MapManager GetMap()
    {
        return _mapManager;
    }

    public PlayerManager GetPlayer()
    {
        return _playerManager;
    }

    public GuardManager GetGuard()
    {
        return _guardManager;
    }

    public GameUIManager GetUI()
    {
        return _gameUIManager;
    }


}
