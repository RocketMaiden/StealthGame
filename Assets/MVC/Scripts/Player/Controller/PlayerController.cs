
using Assets.MVC.Scripts.Ground.View;
using Assets.MVC.Scripts.MapObject;
using Assets.MVC.Scripts.Player.Model;
using Assets.MVC.Scripts.Player.View;
using UnityEngine;

namespace Assets.MVC.Scripts.Player.Controller
{
    public class PlayerController
    {
        private IPlayerModel _playerModel;
        private IPlayerView _playerView;

        public PlayerController(PlayerView view)
        {
            _playerModel = PlayerModel.Create();

            _playerModel.Position = new Vector3(0, 0, 0);
            _playerModel.TargetPosition = _playerModel.Position;
            _playerModel.Rotation = Quaternion.identity;

            MapObjectStorage.AddMapObject(_playerModel);

            _playerView = view;
            _playerView.SetPosition(_playerModel.Position);
            _playerView.SetRotation(_playerModel.Rotation);
        }
        public void Tick()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    var ground = hitInfo.transform.gameObject.GetComponent<IGroundView>();
                    if (ground != null)
                    {
                        _playerModel.TargetPosition = hitInfo.point;                       

                    }                    
                }               
            }

            if(Vector3.Distance(_playerModel.TargetPosition, _playerModel.Position) > 0.2f)
            {
                Vector3 forward = _playerModel.TargetPosition - _playerModel.Position;

                var rotationTarget = Quaternion.LookRotation(forward);

                var angle = Quaternion.Angle(_playerModel.Rotation, rotationTarget);

                float rotationSpeed = 270f * Time.deltaTime;

                float movementSpeed = 3f * Time.deltaTime;


                if (angle <= rotationSpeed)
                {
                    _playerModel.Rotation = rotationTarget;                   
                }
                else
                {
                    _playerModel.Rotation = Quaternion.RotateTowards(_playerModel.Rotation, rotationTarget, rotationSpeed);

                    movementSpeed *= 0.4f;
                }

                _playerModel.Position += (_playerModel.Rotation * Vector3.forward) * movementSpeed;

                MapObjectStorage.UpdateMapObject(_playerModel);                
            }

           

            _playerView.SetRotation(_playerModel.Rotation);
            _playerView.SetPosition(_playerModel.Position);
        }        
       
    }
}
