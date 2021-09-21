using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public Bullet enemyBulletPrefab;
    public Coin coinPrefab;
    public float expiryTimer = 2f;
    public int ammo = 1;
    public float timeBetweenShots = 1f;
    public float minTimeToShoot = 0.5f;
    public float maxTimeToShoot = 2f;
    private GameObject player;
    private Vector2 directionToPlayer;
    private float shootTimer;
    private float deathTimer;
    private BulletSpawner bulletSpawner;
    private float endX;
    private float endY;
    private Vector2 endWorldSpace;
    private Vector2 endViewportSpace;
    private Vector2 direction;
    private Camera cam;
    private bool enteredScreen = false;
    

    private int enemySpawnSide;
    public int EnemySpawnSide
    {
        set
        {
            this.enemySpawnSide = value;
        }
    }
    private Vector2 spawnLocationWorldSpace;
    public Vector2 SpawnLocationWorldSpace
    {
        set
        {
            this.spawnLocationWorldSpace = value;
        }
    }



    
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = expiryTimer;
        cam = FindObjectOfType<Camera>();
        player = GameObject.Find("Player");
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
        shootTimer = Random.Range(minTimeToShoot , maxTimeToShoot);

        switch (enemySpawnSide)
        {
            case 0:
                endX = 1f;
                endY = Random.Range(0.0f, 1.0f);
                break;
            case 1:
                endX = Random.Range(0.0f, 1.0f);
                endY = 0f;
                break;
            case 2:
                endX = 0f;
                endY = Random.Range(0.0f, 1.0f);
                break;
            case 3:
                endX = Random.Range(0.0f, 1.0f);
                endY = 1f;
                break;
            default:
                endX = 0;
                endY = 0;
                break;
        }
        endViewportSpace = new Vector2(endX, endY);
        endWorldSpace = cam.ViewportToWorldPoint(endViewportSpace);
        direction = endWorldSpace - spawnLocationWorldSpace;
        transform.Rotate(Vector3.forward, Vector2.SignedAngle(transform.position, direction));
    }

    // Update is called once per frame
    void Update()
    {
        if(enteredScreen == false)
        if(cam.WorldToViewportPoint(this.transform.position).x<1&& cam.WorldToViewportPoint(this.transform.position).x > 0 && cam.WorldToViewportPoint(this.transform.position).y < 1 && cam.WorldToViewportPoint(this.transform.position).y > 0)
        {
            enteredScreen = true;
        }
        //when player dies
        if (player == null)
        {
            directionToPlayer = Vector2.zero;
        }
        else
        {
            directionToPlayer = player.transform.position - transform.position;
        }
        
        //Lifespan Timer
        if (deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
        }
        if (deathTimer <= 0)
        {
            Destroy(gameObject);
        }

        
        if(enteredScreen)
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if (shootTimer <= 0)
            if (ammo>0) {
                {
                    bulletSpawner.CreateBullet(directionToPlayer, enemyBulletPrefab);
                    ammo -= 1;
                    shootTimer = timeBetweenShots;
                }
            }
        transform.Translate(direction*speed*Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = Instantiate(coinPrefab);
        coin.transform.localPosition = transform.position;
        Destroy(gameObject);
    }
}
