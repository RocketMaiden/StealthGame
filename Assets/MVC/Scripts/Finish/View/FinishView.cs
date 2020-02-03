using System;
using UnityEngine;

namespace Assets.MVC.Scripts.Finish.View
{
    
    public class FinishView : MonoBehaviour, IFinishView
    {
        public  event Action SomethingTouchedFinish;
        private void OnTriggerEnter(Collider other)
        {
            if (SomethingTouchedFinish != null)
            {
                SomethingTouchedFinish.Invoke();
            }
        }
    }
}
