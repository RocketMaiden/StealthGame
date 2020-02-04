using Assets.MVC.Scripts.MapObject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MVC.Scripts.Player.Model
{
    public class PlayerStorage : AStorage<IPlayerModel>
    {
       public static List<IPlayerModel> GetPlayers()
       {
            return GetItem(MapObjectType.Player);
       }

        public static Guid CreateModel()
        {            
            var model = new PlayerModel(Vector3.zero, Quaternion.identity);
           
            model.PlayerVisibleTimer = 1;
            model.TimeToSpotPlayer = 2;

            AddItem(model);

            return model.Guid;            
        }

        public static void Reset()
        {
            _storage = new Dictionary<Guid, IPlayerModel>();
        }
    }

    
}
