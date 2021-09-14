using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    

    
  
    public void CreateBullet(Vector2 bulletDirection, Bullet bulletPrefab)
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.transform.localPosition = transform.position;
        bullet.BulletDirection = bulletDirection;
        
    }
}
