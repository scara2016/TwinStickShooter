using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float expiryTime = 3f;
    public int worth = 1;
    private float expiryTimer;
    private ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        expiryTimer = expiryTime;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (expiryTimer > 0)
        {
            expiryTimer -= Time.deltaTime;
        }
        if (expiryTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(typeof(FlockAgent), out Component component))
        {
            scoreKeeper.AddScore(worth);
            Destroy(gameObject);
        }
    }
}
