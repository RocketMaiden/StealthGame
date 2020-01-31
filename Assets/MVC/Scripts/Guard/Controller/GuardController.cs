using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Guard.View;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Controller
{
    class GuardController
    {
        private IGuardModel _guardModel;
        private IGuardView _guardView;

        public void Initialize(IGuardModel model, IGuardView view)
        {
            _guardModel = model;
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

            _guardView.SetRotation(_guardModel.Rotation);
            _guardView.SetPosition(_guardModel.Position);

        }

        
    }
}
