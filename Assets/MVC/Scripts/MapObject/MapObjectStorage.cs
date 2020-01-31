using System;
using System.Collections.Generic;

namespace Assets.MVC.Scripts.MapObject
{
    public class MapObjectStorage
    {
        private static Dictionary<Guid, IMapObjectModel> _mapStorage = new Dictionary<Guid, IMapObjectModel>();

        public static IMapObjectModel AddMapObject(IMapObjectModel model)
        {            
            _mapStorage.Add(model.Guid, model);
            return model;
        }
        public static IMapObjectModel UpdateMapObject(IMapObjectModel model)
        {
            _mapStorage[model.Guid] = model;
            return model;
        }

        public static IMapObjectModel RemoveMapObject(Guid guid)
        {
            var model = _mapStorage[guid];
            _mapStorage.Remove(guid);
            return model;
        }

        public static IMapObjectModel GetMapObject(Guid guid)
        {
            return _mapStorage[guid];
        }

        public static List<IMapObjectModel> GetMapObject(MapObjectType type)
        {
            var result = new List<IMapObjectModel>();
            foreach(var mapObject in _mapStorage.Values)
            {
                if(mapObject.MapObjectType == type)
                {
                    result.Add(mapObject);
                }
            }
            return result;
        }
    }
}
