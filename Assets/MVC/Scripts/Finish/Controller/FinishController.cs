using Assets.MVC.Scripts.Finish.Model;
using Assets.MVC.Scripts.Finish.View;
using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Finish.Controller
{
    public class FinishController
    {
                
        private Guid _modelGuid;
        private IFinishView _finishView;

        public FinishController(FinishView view)
        {
            _finishView = view;
            _modelGuid = FinishStorage.CreateModel();
            _finishView.SomethingTouchedFinish += React;
        }

        public void Tick()
        {         

            var model = FinishStorage.GetItem(_modelGuid);
            if (model.FinishIsTouched)
            {
                Debug.Log("Finish is touched");
                Debug.Log("Game over - you won");
            }           
        }
        
        private void React()
        {
            var model = FinishStorage.GetItem(_modelGuid);
            model.FinishIsTouched = true;
            FinishStorage.UpdateItem(model);
        }




    }
}
