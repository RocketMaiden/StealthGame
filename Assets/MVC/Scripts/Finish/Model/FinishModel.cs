﻿using Assets.MVC.Scripts.MapObject;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Finish.Model
{
    public struct FinishModel : IFinishModel
    {
        public bool FinishIsTouched { get; set; }

        public Guid Guid { get; set; }

        public MapObjectType MapObjectType { get; set; }

        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public FinishModel(Vector3 position, Quaternion rotation)
        {
            Guid = Guid.NewGuid();
            MapObjectType = MapObjectType.Finish;

            Position = position;            
            Rotation = rotation;

            FinishIsTouched = false;
        }

    }
}
