using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Guard.View;
using Assets.MVC.Scripts.MapObject;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Controller
{
    public class GuardController
    {        
        private IGuardView _view;
        private Guid _modelGuid;

        public GuardController(IGuardView view)
        {
            _view = view;
            _modelGuid = GuardStorage.CreateModel();
        }

        public void Tick()
        {
            var model = GuardStorage.GetItem(_modelGuid);

            float movementSpeed = 2f * Time.deltaTime;
            float rotationSpeed = 270f * Time.deltaTime;

            if (Vector3.Distance(model.TargetPosition, model.Position) > 0.2f)
            {
                Vector3 forward = model.TargetPosition - model.Position;
                var rotationTarget = Quaternion.LookRotation(forward);
                model.Position = Vector3.MoveTowards(model.Position, model.TargetPosition, movementSpeed);
                model.Rotation = Quaternion.RotateTowards(model.Rotation, rotationTarget, rotationSpeed);
            }
            else
            {
                model.CurrentNode++;
                if (model.CurrentNode >= model.PatrolPath.Count)
                {
                    model.CurrentNode = 0;
                }
                var target = model.PatrolPath[model.CurrentNode];
                model.TargetPosition = target;
            }

            GuardStorage.UpdateItem(model);

            _view.SetRotation(model.Rotation);
            _view.SetPosition(model.Position);
            _view.SetLightColor(model.Color);
            _view.SetLightSettings(model.VisionLength, model.VisionAngle);
        }
    }
}
