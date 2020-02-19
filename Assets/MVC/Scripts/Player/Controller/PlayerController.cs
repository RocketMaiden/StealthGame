
using Assets.MVC.Scripts.Player.Config;
using Assets.MVC.Scripts.Player.Model;
using Assets.MVC.Scripts.Player.View;
using Assets.MVC.Scripts.UserInput.Controller;
using System.Collections.Generic;
using Assets.MVC.Scripts.Pathfinder;
using System;
using UnityEngine;
using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Model;

namespace Assets.MVC.Scripts.Player.Controller
{
    public class PlayerController
    {
        private Guid _modelGuid;
        private IPlayerView _playerView;

        public PlayerController(IPlayerConfig config, IPlayerView view)
        {
            _modelGuid = PlayerStorage.CreateModel(config);
            var model = PlayerStorage.GetItem(_modelGuid);

            var position = FieldStorage.GetPlayerSpawn();

            model.GridPosition =  position;
            model.Position = GridUtil.ConvertPointToPosition(position);
            model.GridTargetPosition = position;
            model.TargetPosition = GridUtil.ConvertPointToPosition(position);

            _playerView = view;            
        }
        public void Tick()
        {            
            if (!PlayerStorage.ContainsItem(_modelGuid))
            {
                return;
            }
            var model = PlayerStorage.GetItem(_modelGuid);
            model.GridPosition = GridUtil.ConvertToGrid(model.Position);

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
                    //reset previous path data
                    model.TargetPosition = model.Position;
                    model.GridTargetPosition = model.GridPosition;
                    model.CurrentNode = 0;

                    //get new target
                    model.Path = PathfinderUtil.GetPath(model.GridPosition, InputModelStorage.PopTargetIndex());                   
                }

                //to do получить цель движения

                if (model.Path != null && model.Path.Count > 0)
                {
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
                    else
                    {
                        if (model.CurrentNode < model.Path.Count)
                        {
                            var target = model.Path[model.CurrentNode];
                            model.TargetPosition = GridUtil.ConvertPointToPosition(target);
                            model.CurrentNode++;
                        }
                        else
                        {
                            model.CurrentNode = 0;
                            model.Path = new List<Point>();
                        }
                    }
                }
            }

            PlayerStorage.UpdateItem(model);

            _playerView.SetRotation(model.Rotation);
            _playerView.SetPosition(model.Position);
        }        
       
    }
}
