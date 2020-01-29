using Assets.UnityComponentSystem.Scripts.Managers;
using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.Common
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            GameManager.GetMapManager().FinishIsReached(other.gameObject);
        }
    }
}

