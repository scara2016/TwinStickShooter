using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    BulletSpawner bulletSpawner;
    public Bullet bulletPrefab;
    private float timer;
    public float shootCooldown;
    // Start is called before the first frame update
    void Start()
    {
        timer = shootCooldown;
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0) 
        {
            timer -= Time.deltaTime;
        }
        float shootUp = Input.GetAxis(InputAxes.ShootUp);
        float shootLeft = Input.GetAxis(InputAxes.ShootLeft);
        if (timer<=0) {
            if (Input.GetButton(InputAxes.ShootUp) || Input.GetButton(InputAxes.ShootDown) || Input.GetButton(InputAxes.ShootRight) || Input.GetButton(InputAxes.ShootLeft))
            {
                bulletSpawner.CreateBullet(new Vector2(-shootLeft, shootUp), bulletPrefab);
                timer = shootCooldown;

            }
        }
    }
}
