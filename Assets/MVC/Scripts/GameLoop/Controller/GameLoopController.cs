using Assets.MVC.Scripts.Finish.Model;
using Assets.MVC.Scripts.GameLoop.View;
using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Player.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MVC.Scripts.GameLoop.Controller
{
    public class GameLoopController
    {
        private IGameLoopView _gameLoopView;

        public bool GameIsOver = false;
        public GameLoopController(IGameLoopView view)
        {
            _gameLoopView = view;
        }

        public void Tick()
        {
            var players = PlayerStorage.GetPlayers();
            var finishes = FinishStorage.GetFinishes();

            foreach(var player in players)
            {
                if (player.IsSpotted)
                {
                    _gameLoopView.ShowLoseGame();
                    GameIsOver = true;
                }
            }

            foreach(var finish in finishes)
            {
                if (finish.FinishIsTouched)
                {
                    _gameLoopView.ShowWinGame();
                    GameIsOver = true;
                }
            }
            if(GameIsOver)
            {
                //todo reset game by spacebar
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Restart();                   
                }
            }
        }

        private void Restart()
        {           
            PlayerStorage.Reset();
            GuardStorage.Reset();
            FinishStorage.Reset();
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

    }
}
