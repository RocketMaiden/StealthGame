using Assets.MVC.Scripts.Ground.Model;
using Assets.MVC.Scripts.Ground.View;
using UnityEngine;

namespace Assets.MVC.Scripts.UserInput.Controller
{
    public class UserInputSystem
    {
        public void Tick()
        {
            var model = FieldStorage.GetField();

            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    var ground = hitInfo.transform.gameObject.GetComponent<IGroundView>();
                    if (ground != null)
                    {
                        Vector3 currentPosition = hitInfo.transform.position;

                        Point gridIndex = ConvertToGrid(currentPosition);
                        InputModelStorage.SetTargetIndex(gridIndex);
                        
                        //это в будущем будет точка финиша для пасфайндера
                        
                    }
                }
            }
        }

        private Point ConvertToGrid (Vector3 currentPosition)
        {
            Point gridPosition;
            int gridStep = 1;
            gridPosition.X = Mathf.FloorToInt(currentPosition.x / gridStep);
            gridPosition.Y = Mathf.FloorToInt(currentPosition.y / gridStep);
            return gridPosition;
        }
    }
}
