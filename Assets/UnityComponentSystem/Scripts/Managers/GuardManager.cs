using Assets.UnityComponentSystem.Scripts.Guard;
using System;
using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.Managers
{
    public class GuardManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject guardPrefab = null;

        private GameObject _guard;

        private void Start()
        {
            _guard = Instantiate(guardPrefab);
            _guard.transform.SetParent(this.transform);
        }

        public void UpdateVisibilityOfPlayer(float visability)
        {
            if (Mathf.Approximately(visability, 1))
            {
                DisableTarget();
                GameManager.GetGameManager().GetPlayer().DisableTarget();
                GameManager.GetGameManager().GetUI().ShowGameLoseUI();
            }
        }

        public Vector3 GetTargetPosition()
        {
            return GameManager.GetGameManager().GetPlayer().GetCurrentPosition();
        }

        public void DisableTarget()
        {
            _guard.GetComponent<GuardVision>().enabled = false;            
        }
    }
}

