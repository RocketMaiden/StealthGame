using Assets.MVC.Scripts.MapObject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Model
{
    public class GuardStorage : AStorage<IGuardModel>
    {
        public static List<IGuardModel> GetGuards()
        {
            return GetItem(MapObjectType.Guard);
        }

        public static Guid CreateModel()
        {
            var model = new GuardModel(Vector3.zero, Quaternion.identity);

            model.PatrolPath.Add(new Vector3(5, 0, 5));
            model.PatrolPath.Add(new Vector3(-5, 0, 5));
            model.PatrolPath.Add(new Vector3(-5, 0, -5));
            model.PatrolPath.Add(new Vector3(5, 0, -5));

            model.CurrentNode = 0;
            model.Position = model.PatrolPath[model.CurrentNode];
            model.TargetPosition = model.Position;            

            model.VisionAngle = 55;
            model.VisionLength = 10;           

            model.Color = Color.green;

            model.LayerMask = LayerMask.NameToLayer("Obstacle");

            AddItem(model);            

            return model.Guid;
        }      

        public static void Reset()
        {
            _storage = new Dictionary<Guid, IGuardModel>();
        }
    }
}
