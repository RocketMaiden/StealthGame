using Assets.UnityComponentSystem.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UnityComponentSystem.Scripts.Managers
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _mapPrefab = null;

        private GameObject _map;

        private List<Vector3> _path;


        private void Start()
        {
            _map = Instantiate(_mapPrefab);
            _map.transform.SetParent(this.transform);
            var pathHolder = _map.GetComponent<PathHolder>();
            _path = pathHolder.GetPathHolder();

        }

        public void FinishIsReached(GameObject other)
        {
            if (GameManager.GetGameManager().GetPlayer().IsItPlayer(other))
            {
                GameManager.GetGameManager().GetGuard().DisableTarget();
                GameManager.GetGameManager().GetPlayer().DisableTarget();
                GameManager.GetGameManager().GetUI().ShowGameWinUI();
            }
        }

        public List<Vector3> GetPath()
        {
            return _path;
        }
    }

}
