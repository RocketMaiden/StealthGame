﻿using System;
using System.Collections.Generic;

namespace Assets.MVC.Scripts.MapObject
{
    public class AStorage<T> where T : IMapObjectModel
    {
        protected static Dictionary<Guid, T> _storage = new Dictionary<Guid, T>();

        public static T AddItem(T model)
        {            
            _storage.Add(model.Guid, model);
            return model;
        }
        public static T UpdateItem(T model)
        {
            if (_storage.ContainsKey(model.Guid))
            {
                _storage[model.Guid] = model;
            }
            return model;
        }

        public static T RemoveItem(Guid guid)
        {
            if (_storage.ContainsKey(guid))
            {
                var model = _storage[guid];
                _storage.Remove(guid);
                return model;
            }
            return default;
        }

        public static T GetItem(Guid guid)
        {
            if (_storage.ContainsKey(guid))
            {
                return _storage[guid];
            }
            return default;
        }
        public static bool ContainsItem(Guid guid)
        {
            return _storage.ContainsKey(guid);           
        }

        protected static List<T> GetItem(MapObjectType type)
        {
            var result = new List<T>();
            foreach (var mapObject in _storage.Values)
            {
                if (mapObject.MapObjectType == type)
                {
                    result.Add(mapObject);
                }
            }
            return result;
        }
    
    }
}
