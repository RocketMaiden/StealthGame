﻿using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Config;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.Model
{
    public struct FieldModel
    {
        public int Width => _width;
        public int Height => _height;
        public Node[,] Field => _field;

        private Node[,] _field;
        private int _width;
        private int _height;

        public FieldModel(IFieldConfig config)
        {
            _width = config.Width;
            _height = config.Height;
            _field = new Node[_width, _height];
            
          
        }

        public void  SetNode(Node node)
        {
            if(node == null)
            {
                Debug.LogError("why u wanna add null node to me bro!?");
            }
            if (node.Point.X < 0 || node.Point.X >= _width ||
                node.Point.Z < 0 || node.Point.Z >= _height)
            {
                Debug.LogError("you are trying to add a node that has its coordinates out of range or your node doesn't exist in a first place");                
            }
            else
            {
                _field[node.Point.X, node.Point.Z] = node;
            }
        }
        public Node GetNode(Point point)
        {
            if (point.X < 0 || point.X >= _width||
                point.Z < 0 || point.Z >= _height)
            {
                Debug.LogError("point coordinates are out of range");
                return null;
                
            }
            else
            {
                return _field[point.X, point.Z];
            }
        }
    }
}
