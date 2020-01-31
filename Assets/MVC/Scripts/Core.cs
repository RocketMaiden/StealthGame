using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.Model;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Guard.View;


using UnityEngine;
using System.Collections.Generic;

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
        _playerController = new PlayerController();
        _playerController.Initialize(new PlayerModel() { Rotation = Quaternion.identity }, _playerView);

        _guardController = new GuardController();
        _guardController.Initialize(new GuardModel()
        {
            Position = new Vector3(5, 0, 5),
            TargetPosition = new Vector3(5, 0, 5),
            Rotation = Quaternion.identity,
            PatrolPath = new List<Vector3>()
            {
                new Vector3(5,0,5),
                new Vector3(-5,0,5),
                new Vector3(-5,0,-5),
                new Vector3(5,0,-5),
            },
            CurrentNode = 0,
            VisionLength = 10,
            VisionAngle = 35,
            PlayerVisibleTimer = 2,
            Color = Color.green,                         
        },
        _guardView);

        
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
