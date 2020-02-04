using Assets.MVC.Scripts.Guard.Model;
using Assets.MVC.Scripts.Player.Model;
using UnityEngine;

namespace Assets.MVC.Scripts.Guard.Controller
{
    public class GuardVisionSystem
    {
        public void Tick()
        {
            var guards = GuardStorage.GetGuards();
            var players = PlayerStorage.GetPlayers();


            foreach (var player in players)
            {
                foreach (var guard in guards)
                {
                    if (CanSeeTarget(guard, player))
                    {
                        player.PlayerVisibleTimer += Time.deltaTime;
                    }
                    else
                    {
                        player.PlayerVisibleTimer -= Time.deltaTime;
                    }

                    player.PlayerVisibleTimer = Mathf.Clamp(player.PlayerVisibleTimer, 0, player.TimeToSpotPlayer);

                    float _visability = player.PlayerVisibleTimer / player.TimeToSpotPlayer;

                    guard.Color = Color.Lerp(Color.green, Color.red, _visability);

                    GuardStorage.UpdateItem(guard);
                }

                PlayerStorage.UpdateItem(player);
            }
        }

        private bool CanSeeTarget(IGuardModel guard, IPlayerModel player)
        {
            float viewDistanceSq = guard.VisionLength * guard.VisionLength;
            Vector3 offset = player.Position - guard.Position;
            float sqrDistance = offset.sqrMagnitude;
            if (sqrDistance < viewDistanceSq)
            {
                Vector3 directionToTarget = offset.normalized;
                var forward = guard.Rotation * Vector3.forward;
                float angleBetweenMeAndTarget = Vector3.Angle(forward, directionToTarget);
                if (angleBetweenMeAndTarget < guard.VisionAngle / 2)
                {                    
                    var isObstacle = Physics.Linecast(guard.Position, player.Position, guard.LayerMask);                    
                    if (!isObstacle)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
