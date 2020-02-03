using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.View;

using UnityEngine;
using Assets.MVC.Scripts.Finish.View;
using Assets.MVC.Scripts.Finish.Controller;

public class Core : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView = null;

    [SerializeField]
    private GuardView _guardView = null;

    [SerializeField]
    private FinishView _finishView = null;
    
    private PlayerController _playerController;
    private GuardController _guardController;
    private FinishController _finishConroller;

    private GuardVisionSystem _guardVisionSystem;

    private void Awake()
    {
        _playerController = new PlayerController(_playerView);

        _guardController = new GuardController(_guardView);

        _guardVisionSystem = new GuardVisionSystem();

        _finishConroller = new FinishController(_finishView);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _guardVisionSystem.Tick();

        _playerController.Tick();
        _guardController.Tick();
        _finishConroller.Tick();
    }
}
