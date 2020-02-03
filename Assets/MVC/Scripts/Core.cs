using Assets.MVC.Scripts.Player.Controller;
using Assets.MVC.Scripts.Player.View;

using Assets.MVC.Scripts.Guard.Controller;
using Assets.MVC.Scripts.Guard.View;

using UnityEngine;


public class Core : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerView = null;

    [SerializeField]
    private GuardView _guardView = null;
    
    private PlayerController _playerController;
    private GuardController _guardController;

    private GuardVisionSystem _guardVisionSystem;

    private void Awake()
    {
        _playerController = new PlayerController(_playerView);

        _guardController = new GuardController(_guardView);

        _guardVisionSystem = new GuardVisionSystem();
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
    }
}
