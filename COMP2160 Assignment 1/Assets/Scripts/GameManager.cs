using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameStarted()
    {
        scoreKeeper.GameStarted();
        uiManager.GameStarted();
    }
    public void GameEnded()
    {
        scoreKeeper.GameEnded();
        uiManager.GameEnded();
    }
}
