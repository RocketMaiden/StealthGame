using Assets.MVC.Scripts.Grid;
using Assets.MVC.Scripts.Ground.Config;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.Model
{
    public struct FieldModel
    {
        public int Width { get; }
        public int Height { get; }
        public Node[,] Field { get; }

        public FieldModel(IFieldConfig config)
        {
            Width = config.Width;
            Height = config.Height;
            Field = new Node[Width, Height];
        }

        public void  SetNode(Node node)
        {
            if(node == null)
            {
                Debug.LogError("why u wanna add null node to me bro!?");
                return;
            }
            if (IsValidNode(node.Point))
            {
                Field[node.Point.X, node.Point.Z] = node;                
            }
            else
            {
                Debug.LogError("you are trying to add a node that has its coordinates out of range or your node doesn't exist in a first place");
            }
        }

        public void SetNodeValue(Point point, int value)
        {
            if (IsValidNode(point))
            {
                Field[point.X, point.Z].PathValue = value;
            }
            else
            {
                Debug.LogError("you are trying to SetNodeValue to the node that has its coordinates out of range or your node doesn't exist in a first place");
            }
        }

        public int GetNodeValue(Point point)
        {
            if (IsValidNode(point))
            {
                return Field[point.X, point.Z].PathValue;
            }
            else
            {
                Debug.LogError("you are trying to SetNodeValue to the node that has its coordinates out of range or your node doesn't exist in a first place");
                return int.MinValue;
            }
        }

        public Node GetNode(Point point)
        {
            if (IsValidNode(point))
            {
                return Field[point.X, point.Z]; 
            }
            else
            {
                Debug.LogError("point coordinates are out of range");
                return null;
            }
        }

        public bool IsValidNode(Point point)
        {
            if (point.X < 0 || point.X >= Width ||
                point.Z < 0 || point.Z >= Height)
            {
                return false;
            }           
            return true;
        }
    }
}
