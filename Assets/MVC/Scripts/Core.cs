using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.View;

using UnityEngine;

using Assets.MVC.Scripts.GameLoop.View;
using Assets.MVC.Scripts.GameLoop.Controller;
using Assets.MVC.Scripts.Guard.Config;
using Assets.MVC.Scripts.Player.Config;
using Assets.MVC.Scripts.Ground.Controller;
using Assets.MVC.Scripts.UserInput.Controller;
using Assets.MVC.Scripts.Ground.Config;
using Assets.MVC.Scripts.Ground.View;

public class Core : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private PlayerView _playerView = null;
    [SerializeField]
    private PlayerConfig _playerConfig = null;
    private PlayerController _playerController;

    [Header("Guard")]
    [SerializeField]
    private GuardView _guardView = null;
    [SerializeField]
    private GuardConfig _guardConfig = null;
    private GuardController _guardController;

    [Header("Field")]
    [SerializeField]
    private FieldView _fieldView = null;
    [SerializeField]
    private FieldConfig _fieldConfig = null;
    private FieldController _fieldContrcoller;


    [Header("GamePlay")] 
    [SerializeField]
    private GameLoopView _gameLoop = null;
    private GameLoopController _gameLoopController;
    private GuardVisionSystem _guardVisionSystem;
    private UserInputSystem _userInputSystem;
    

    private void Awake()
    {
        _fieldContrcoller = new FieldController(_fieldConfig, _fieldView);

        _playerController = new PlayerController(_playerConfig, _playerView);

        _guardController = new GuardController(_guardConfig, _guardView);

        _guardVisionSystem = new GuardVisionSystem();

        _userInputSystem = new UserInputSystem();

        _gameLoopController = new GameLoopController(_gameLoop);

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
                      
        }
        _playerController.Tick();
        _guardController.Tick();

        _fieldContrcoller.Tick();

    }
}
