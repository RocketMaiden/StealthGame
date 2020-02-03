using Assets.MVC.Scripts.MapObject;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MVC.Scripts.Finish.Model
{
    public class FinishStorage : AStorage<IFinishModel>
    {
        public static List<IFinishModel> GetFinishes()
        {
            return GetItem(MapObjectType.Finish);
        }

        public static Guid CreateModel()
        {
            var model = new FinishModel(Vector3.zero, Quaternion.identity);

            AddItem(model);

            return model.Guid;
        }
    }
}
