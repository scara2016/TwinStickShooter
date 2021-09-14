using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnTimer= 3f;
    public float spawnTimerMin = 1f;
    public float spawnTimeDeprecationRate = 0.2f;
    
    private float timer;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        timer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer>0)
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            spawnEnemy();
            if (spawnTimer > spawnTimerMin)
            {
                spawnTimer -= spawnTimeDeprecationRate;
            }
            timer = spawnTimer;
        }
    }
    private void spawnEnemy()
    {
        Vector2 spawnPointViewportSpace;
        Vector2 spawnPointWorldSpace;
        float spawnX;
        float spawnY;
        //0 = left, 1 = up, 2 = right, 3 = down
        int side = Mathf.FloorToInt(Random.Range(0, 3.99f));
        switch(side){
            case 0:
                spawnX = -0.5f;
                spawnY = Random.Range(0.0f, 1.0f);
                break;
            case 1:
                spawnX = Random.Range(0.0f, 1.0f);
                spawnY = 1.5f;
                break;
            case 2:
                spawnX = 1.5f;
                spawnY = Random.Range(0.0f, 1.0f);
                break;
            case 3:
                spawnX = Random.Range(0.0f, 1.0f);
                spawnY = -0.5f;
                break;
            default:
                spawnX = 0f;
                spawnY = 0f;
                break;
        }
        
        spawnPointViewportSpace = new Vector2(spawnX, spawnY);
        spawnPointWorldSpace =  cam.ViewportToWorldPoint(spawnPointViewportSpace);
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.transform.localPosition = spawnPointWorldSpace;
        enemy.EnemySpawnSide = side;
        enemy.SpawnLocationWorldSpace = spawnPointWorldSpace;
        
                

    }
}
