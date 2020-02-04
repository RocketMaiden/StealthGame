using System;
using UnityEngine;

namespace Assets.MVC.Scripts.GameLoop.View
{
    public class GameLoopView : MonoBehaviour, IGameLoopView
    {
        [SerializeField]
        private GameObject loseGamePopup;
        [SerializeField]
        private GameObject winGamePopUp;

        public void ShowLoseGame()
        {
            loseGamePopup.SetActive(true);
        }

        public void ShowWinGame()
        {
            winGamePopUp.SetActive(true);
        }
    }
}
