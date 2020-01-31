using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.Model;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Guard.View;


using UnityEngine;
using System.Collections.Generic;
using Assets.MVC.Scripts.MapObject;

public class Core : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView = null;

    [SerializeField]
    private GuardView _guardView = null;
    
    private PlayerController _playerController;
    private GuardController _guardController;





    private void Awake()
    {
        _playerController = new PlayerController(_playerView);

        _guardController = new GuardController(_guardView);    
        

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerController.Tick();
        _guardController.Tick();
    }
}
