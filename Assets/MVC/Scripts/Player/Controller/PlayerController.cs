
using Assets.MVC.Scripts.Ground.View;
using Assets.MVC.Scripts.Player.Config;
using Assets.MVC.Scripts.Player.Model;
using Assets.MVC.Scripts.Player.View;
using Assets.MVC.Scripts.UserInput.Controller;
using System.Collections.Generic;
using Assets.MVC.Scripts.Pathfinder;
using System;
using UnityEngine;
using Assets.MVC.Scripts.Grid;

namespace Assets.MVC.Scripts.Player.Controller
{
    public class PlayerController
    {
        private Guid _modelGuid;
        private IPlayerView _playerView;

        public PlayerController(IPlayerConfig config, IPlayerView view)
        {
            _modelGuid = PlayerStorage.CreateModel(config);
            _playerView = view;
            
        }
        public void Tick()
        {
            List<Point> _path;

            if (!PlayerStorage.ContainsItem(_modelGuid))
            {
                return;
            }
            var model = PlayerStorage.GetItem(_modelGuid);

            var visability = model.PlayerVisibleTimer / model.TimeToSpotPlayer;

            if (Mathf.Approximately(visability, 1f))
            {
                Debug.LogWarning("Player Spoted!!!");
                model.IsSpotted = true;
            }

            if (!model.IsSpotted)
            {

                if (InputModelStorage.IsClicked())
                {
                    var targetPoint = InputModelStorage.PopTargetIndex();

                    _path = PathfinderUtil.GetPath(model.GridPosition, targetPoint);
                    //уточнить, является ли model.gridPosition = model.currentPosition
                }                

                //to do получить цель движения



                if (Vector3.Distance(model.TargetPosition, model.Position) > 0.2f)
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

                //else
                //{
                //    //model.;
                //    if (model.CurrentNode >= model.PatrolPath.Count)
                //    {
                //        model.CurrentNode = 0;
                //    }
                //    var target = model.PatrolPath[model.CurrentNode];
                //    model.TargetPosition = target;
                //}
                //GuardStorage.UpdateItem(model);
            }

            PlayerStorage.UpdateItem(model);

            _playerView.SetRotation(model.Rotation);
            _playerView.SetPosition(model.Position);
        }        
       
    }
}
