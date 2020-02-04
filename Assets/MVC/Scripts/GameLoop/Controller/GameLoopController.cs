using Assets.MVC.Scripts.Finish.Model;
using Assets.MVC.Scripts.GameLoop.View;
using Assets.MVC.Scripts.Player.Model;

namespace Assets.MVC.Scripts.GameLoop.Controller
{
    public class GameLoopController
    {
        private IGameLoopView _gameLoopView;


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
                }
            }

            foreach(var finish in finishes)
            {
                if (finish.FinishIsTouched)
                {
                    _gameLoopView.ShowWinGame();
                }
            }
        }

    }
}
