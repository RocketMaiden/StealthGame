using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.View;

using UnityEngine;
using Assets.MVC.Scripts.Finish.View;
using Assets.MVC.Scripts.Finish.Controller;
using Assets.MVC.Scripts.GameLoop.View;
using Assets.MVC.Scripts.GameLoop.Controller;

public class Core : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView = null;

    [SerializeField]
    private GuardView _guardView = null;

    [SerializeField]
    private FinishView _finishView = null;

    [SerializeField]
    private GameLoopView _gameLoop = null;
    
    private PlayerController _playerController;
    private GuardController _guardController;
    private FinishController _finishConroller;

    private GuardVisionSystem _guardVisionSystem;

    private GameLoopController _gameLoopController;

    private void Awake()
    {
        _playerController = new PlayerController(_playerView);

        _guardController = new GuardController(_guardView);

        _guardVisionSystem = new GuardVisionSystem();

        _finishConroller = new FinishController(_finishView);

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
            _guardVisionSystem.Tick();
            _playerController.Tick();
            _finishConroller.Tick();
        }

        _guardController.Tick();

    }
}
