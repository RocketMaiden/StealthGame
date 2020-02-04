using Assets.MVC.Scripts.Guard.Config;
using Assets.MVC.Scripts.MapObject;
using System;
using System.Collections.Generic;

namespace Assets.MVC.Scripts.Guard.Model
{
    public class GuardStorage : AStorage<IGuardModel>
    {
        public static List<IGuardModel> GetGuards()
        {
            return GetItem(MapObjectType.Guard);
        }

        public static Guid CreateModel(IGuardConfig config)
        {
            var model = new GuardModel(config);
            AddItem(model);
            return model.Guid;
        }      

        public static void Reset()
        {
            _storage = new Dictionary<Guid, IGuardModel>();
        }
    }
}
