using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float lifespan = 1f;
    private float timer;
    private Vector2 bulletDirection;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        transform.Translate(bulletSpeed * bulletDirection * Time.deltaTime);
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
