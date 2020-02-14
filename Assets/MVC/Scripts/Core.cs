using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.View;

using UnityEngine;
using Assets.MVC.Scripts.Finish.View;
using Assets.MVC.Scripts.Finish.Controller;
using Assets.MVC.Scripts.GameLoop.View;
using Assets.MVC.Scripts.GameLoop.Controller;
using Assets.MVC.Scripts.Guard.Config;
using Assets.MVC.Scripts.Player.Config;
using Assets.MVC.Scripts.Ground.Controller;
using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.UserInput.Controller;

public class Core : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView = null;

    [SerializeField]
    private GuardView _guardView = null;

    [SerializeField]
    private GuardConfig _guardConfig = null;

    [SerializeField]
    private PlayerConfig _playerConfig = null;

    [SerializeField]
    private FinishView _finishView = null;

    [SerializeField]
    private GameLoopView _gameLoop = null;

    [SerializeField]
    private GameObject _nodePrefab = null;

    private PlayerController _playerController;
    private GuardController _guardController;
    private FinishController _finishConroller;

    private GuardVisionSystem _guardVisionSystem;

    private GameLoopController _gameLoopController;

    private FieldController _fieldContrcoller;

    private UserInputSystem _userInputSystem;
    

    private void Awake()
    {
        _playerController = new PlayerController(_playerConfig, _playerView);

        _guardController = new GuardController(_guardConfig, _guardView);

        _guardVisionSystem = new GuardVisionSystem();

        _userInputSystem = new UserInputSystem();

        _finishConroller = new FinishController(_finishView);

        _gameLoopController = new GameLoopController(_gameLoop);

        _fieldContrcoller = new FieldController(_nodePrefab);


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        _gameLoopController.Tick();
        if (!_gameLoopController.GameIsOver)
        {
            _userInputSystem.Tick();
            _guardVisionSystem.Tick();
            _playerController.Tick();
            _finishConroller.Tick();
        }

        _guardController.Tick();

    }
}
