using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text[] texts;
    private Text coinCounter;
    private Text highScoreText;
    private GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel = GameObject.Find("Game Over");
        texts = transform.GetComponentsInChildren<Text>();
        coinCounter = texts[0];
        highScoreText = texts[1];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoinCount(int Score)
    {
        coinCounter.text = "Coins:- " + Score;
    }

    public void UpdateHighScoreCounter(int highScore)
    {
        highScoreText.text = "HighScore:- " + highScore;
    }
    public void GameStarted()
    {
        gameOverPanel.SetActive(false);
    }
    public void GameEnded()
    {
        
        gameOverPanel.SetActive(true);
    }
}
