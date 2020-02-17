using Assets.MVC.Scripts.Grid;
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

                        Point gridIndex = GridUtil.ConvertToGrid(currentPosition);
                        InputModelStorage.SetTargetIndex(gridIndex);
                        
                        //это в будущем будет точка финиша для пасфайндера
                        
                    }
                }
            }
        }


       
    }
}
