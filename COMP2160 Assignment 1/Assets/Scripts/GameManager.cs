using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private ScoreKeeper scoreKeeper;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        cam = FindObjectOfType<Camera>();
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
    public int EdgeReached(Transform target)
    {
        Vector2 targetViewportPosition = cam.WorldToViewportPoint(target.position);
        if (targetViewportPosition.x < 0)
            return 1;
        else if (targetViewportPosition.x > 1)
            return 3;
        else if (targetViewportPosition.y < 0)
            return 4;
        else if (targetViewportPosition.y > 1)
            return 2;
        else
            return 0;
    }
}
