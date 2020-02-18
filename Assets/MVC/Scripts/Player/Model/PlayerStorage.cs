using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.MapObject;
using Assets.MVC.Scripts.Player.Config;
using System;
using System.Collections.Generic;


namespace Assets.MVC.Scripts.Player.Model
{
    public class PlayerStorage : AStorage<IPlayerModel>
    {
       public static List<IPlayerModel> GetPlayers()
       {
            return GetItem(NodeType.Player);
       }

        public static Guid CreateModel(IPlayerConfig config)
        {            
            var model = new PlayerModel(config);

            AddItem(model);

            return model.Guid;            
        }

        public static void Reset()
        {
            _storage = new Dictionary<Guid, IPlayerModel>();
        }
    }

    
}
