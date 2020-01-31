using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Guard.View;
using Assets.MVC.Scripts.MapObject;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Controller
{
    class GuardController
    {
        private IGuardModel _guardModel;
        private IGuardView _guardView;

        public GuardController(IGuardView view)
        {
            _guardModel = GuardModel.Create();

            _guardModel.PatrolPath.Add(new Vector3(5, 0, 5));
            _guardModel.PatrolPath.Add(new Vector3(-5, 0, 5));
            _guardModel.PatrolPath.Add(new Vector3(-5, 0, -5));
            _guardModel.PatrolPath.Add(new Vector3(5, 0, -5));
            
            _guardModel.CurrentNode = 0;
            _guardModel.Position = _guardModel.PatrolPath[_guardModel.CurrentNode];
            _guardModel.TargetPosition = _guardModel.Position;

            _guardModel.Rotation = Quaternion.identity;
           
            _guardModel.VisionAngle = 35;
            _guardModel.VisionLength = 10;
            _guardModel.PlayerVisibleTimer = 2;
            _guardModel.Color = Color.green;

            MapObjectStorage.AddMapObject(_guardModel);

            _guardView = view;
            _guardView.SetPosition(_guardModel.Position);
            _guardView.SetRotation(_guardModel.Rotation);
            _guardView.SetLightColor(_guardModel.Color);
            _guardView.SetLightSettings(_guardModel.VisionLength, _guardModel.VisionAngle);
            
        }          

        public void Tick()
        {
            float movementSpeed = 3f * Time.deltaTime;
            float rotationSpeed = 270f * Time.deltaTime;

            if (Vector3.Distance(_guardModel.TargetPosition, _guardModel.Position) > 0.2f)
            {
                Vector3 forward = _guardModel.TargetPosition - _guardModel.Position;
                var rotationTarget = Quaternion.LookRotation(forward);
                _guardModel.Position = Vector3.MoveTowards(_guardModel.Position, _guardModel.TargetPosition, movementSpeed);
                _guardModel.Rotation = Quaternion.RotateTowards(_guardModel.Rotation, rotationTarget, rotationSpeed);
            }
            else
            {
                _guardModel.CurrentNode++;
                if (_guardModel.CurrentNode >= _guardModel.PatrolPath.Count)
                {
                    _guardModel.CurrentNode = 0;
                }
                var target = _guardModel.PatrolPath[_guardModel.CurrentNode];
                _guardModel.TargetPosition = target;
            }

            if (CanSeeTarget())
            {
                _guardModel.Color = Color.red;
            }
            else
            {
                _guardModel.Color = Color.green;
            }

            _guardView.SetRotation(_guardModel.Rotation);
            _guardView.SetPosition(_guardModel.Position);
            _guardView.SetLightColor(_guardModel.Color);
        }

        public bool CanSeeTarget()
        {
            var players = MapObjectStorage.GetMapObject(MapObjectType.Player);
            foreach (var player in players)
            {
                float viewDistanceSq = _guardModel.VisionLength * _guardModel.VisionLength;
                Vector3 offset = player.Position - _guardModel.Position;
                float sqrDistance = offset.sqrMagnitude;
                if (sqrDistance < viewDistanceSq)
                {
                    Vector3 directionToTarget = offset.normalized;
                    var forward = _guardModel.Rotation * Vector3.forward;
                    float angleBetweenMeAndTarget = Vector3.Angle(forward, directionToTarget);
                    if (angleBetweenMeAndTarget < _guardModel.VisionAngle / 2)
                    {
                        if (!Physics.Linecast(_guardModel.Position, player.Position))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        
    }
}
