using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private UIManager uiManager;
    private int score;
    private int highScore;
    static private ScoreKeeper instance;
    static public ScoreKeeper Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("There is no ScoreKeeper");
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    }

    public void GameStarted()
    {
        score = 0;
        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateCoinCount(score);
        uiManager.UpdateHighScoreCounter(highScore);
        score = 0;
    }
    public void GameEnded()
    {

    }
    public void AddScore(int points)
    {
        score += points;
        uiManager.UpdateCoinCount(score);
        if (highScore < score)
        {
            highScore = score;
            uiManager.UpdateHighScoreCounter(highScore);
        }
    }
}
