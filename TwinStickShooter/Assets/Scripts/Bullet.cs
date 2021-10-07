using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float lifespan = 1f;
    private float timer;
    private Vector2 bulletDirection;
    private GameManager gameManager;
    public bool canColideWithFlock;
    public Vector2 BulletDirection
    {
        set
        {
            this.bulletDirection = value;
        }
    }
    

    

    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        transform.Translate(bulletSpeed * bulletDirection.normalized * Time.deltaTime);
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        if (gameManager.EdgeReached(this.transform) > 0)
        {
           Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(canColideWithFlock)
        if (!collision.gameObject.TryGetComponent(typeof(Coin), out Component component) && !collision.gameObject.TryGetComponent(typeof(FlockAgent), out Component component1))
        {
            Destroy(gameObject);
        }
        else
            {
                if (!collision.gameObject.TryGetComponent(typeof(Coin), out Component component2))
                {
                    Destroy(gameObject);
                }
            }
    }
}
