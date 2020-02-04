using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MVC.Scripts.GameLoop.Controller
{
    public class GameLoadingController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}