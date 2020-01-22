using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    public AIVision AIVision;
    public Finish Finish;


    bool _gameIsOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        AIVision.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        Finish.FinishIsTouched += ShowGameWinUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void ShowGameWinUI()
    {
        OnGameOver(gameWinUI);
    }

    void ShowGameLoseUI(float visability)
    {
        if (Mathf.Approximately(visability, 1))
        {
            OnGameOver(gameLoseUI);
        }
    }

    void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
        _gameIsOver = true;
        AIVision.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        Finish.FinishIsTouched -= ShowGameWinUI;

    }
}
