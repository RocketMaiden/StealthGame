using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Guard.Config;
using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Guard.View;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Controller
{
    public class GuardController
    {        
        private IGuardView _view;
        private Guid _modelGuid;

        public GuardController(IGuardConfig config, IGuardView view)
        {
            _view = view;
            _modelGuid = GuardStorage.CreateModel(config);
        }

        public void Tick()
        {
            if (!GuardStorage.ContainsItem(_modelGuid))
            {
                return;
            }
            var model = GuardStorage.GetItem(_modelGuid);

            if (Vector3.Distance(model.TargetPosition, model.Position) > 0.2f)
            {
                float movementSpeed = 2f * Time.deltaTime;
                float rotationSpeed = 270f * Time.deltaTime;

                Vector3 forward = model.TargetPosition - model.Position;
                var rotationTarget = Quaternion.LookRotation(forward);
                model.Position = Vector3.MoveTowards(model.Position, model.TargetPosition, movementSpeed);
                model.Rotation = Quaternion.RotateTowards(model.Rotation, rotationTarget, rotationSpeed);
            }
            else
            {
                model.CurrentNode++;
                if (model.CurrentNode >= model.Path.Count)
                {
                    model.CurrentNode = 0;
                }
                var target = model.Path[model.CurrentNode];
                model.GridTargetPosition = target;
                model.TargetPosition = GridUtil.ConvertPointToPosition(target);
            }
            GuardStorage.UpdateItem(model);


            _view.SetRotation(model.Rotation);
            _view.SetPosition(model.Position);
            _view.SetLightColor(model.Color);
            _view.SetLightSettings(model.VisionLength, model.VisionAngle);
        }
    }
}
