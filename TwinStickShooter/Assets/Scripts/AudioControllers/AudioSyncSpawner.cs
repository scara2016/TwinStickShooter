using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncSpawner : AudioSyncer
{
    private Enemy enemy;
   
    // Start is called before the first frame update

    public void Start()
    {
        enemy = GetComponent<Enemy>();
        
    }
    public override void OnBeat()
    {
        base.OnBeat();
        enemy.Shoot();
        
        
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        base.OnUpdate();
        
        
        
    }
    public void Spawner()
    {
        if (m_isBeat)
        {
            enemy.Shoot();
        }
    }

  
}

