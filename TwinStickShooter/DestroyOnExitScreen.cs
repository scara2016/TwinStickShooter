using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExitScreen : MonoBehaviour
// Start is called before the first frame update
{
    Vector2 agentWorldPosition;
    Vector2 agentViewPortPosition;
    bool hasEnteredScreen = false;
    bool activateDeathTimer = false;
    public float deathTimer = 1f;
    float timer;
    Camera cam;
    void Start()
    {
        timer = deathTimer;
        cam = FindObjectOfType<Camera>();
        
    }
    void Update()
    {

        if (activateDeathTimer)
        {
            timer--;
        }
        if (timer == 0)
        {
            Destroy();
        }

        agentViewPortPosition = cam.WorldToViewportPoint(transform.position);
        if (!hasEnteredScreen)
        {
            if(agentViewPortPosition.x>0 || agentViewPortPosition.x<1 || agentViewPortPosition.y>0 || agentViewPortPosition.y<1)
            {
                hasEnteredScreen = true;
            }
        }
        else if (hasEnteredScreen)
        {
            if (agentViewPortPosition.x < 0 || agentViewPortPosition.x > 1 || agentViewPortPosition.y < 0 || agentViewPortPosition.y > 1)
            {
                hasEnteredScreen = true;
            }
        }
    }
    void Destroy()
    {
            this.gameObject.
    }

}