
using Assets.MVC.Scripts.Ground.View;
using Assets.MVC.Scripts.Player.Model;
using Assets.MVC.Scripts.Player.View;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Player.Controller
{
    public class PlayerController
    {
        private Guid _modelGuid;
        private IPlayerView _playerView;

        public PlayerController(PlayerView view)
        {
            _modelGuid = PlayerStorage.CreateModel();
            _playerView = view;
            
        }
        public void Tick()
        {
            var model = PlayerStorage.GetItem(_modelGuid);

            var visability = model.PlayerVisibleTimer / model.TimeToSpotPlayer;

            if (Mathf.Approximately(visability, 1f))
            {
                Debug.LogWarning("Player Spoted!!!");
            }

            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    var ground = hitInfo.transform.gameObject.GetComponent<IGroundView>();
                    if (ground != null)
                    {
                        model.TargetPosition = hitInfo.point;

                    }
                }
            }            

            if(Vector3.Distance(model.TargetPosition, model.Position) > 0.2f)
            {
                Vector3 forward = model.TargetPosition - model.Position;

                var rotationTarget = Quaternion.LookRotation(forward);

                var angle = Quaternion.Angle(model.Rotation, rotationTarget);

                float rotationSpeed = 270f * Time.deltaTime;

                float movementSpeed = 5f * Time.deltaTime;


                if (angle <= rotationSpeed)
                {
                    model.Rotation = rotationTarget;                   
                }
                else
                {
                    model.Rotation = Quaternion.RotateTowards(model.Rotation, rotationTarget, rotationSpeed);

                    movementSpeed *= 0.4f;
                }

                model.Position += (model.Rotation * Vector3.forward) * movementSpeed;                              
            }

            PlayerStorage.UpdateItem(model);

            _playerView.SetRotation(model.Rotation);
            _playerView.SetPosition(model.Position);
        }        
       
    }
}
