using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FlockAgent))]
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
    FlockAgent flockAgent;
    void Start()
    {
        timer = deathTimer;
        cam = FindObjectOfType<Camera>();
        flockAgent = GetComponent<FlockAgent>();
    }
    void Update()
    {

        if (activateDeathTimer)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            flockAgent.Reposition(cam);
            hasEnteredScreen = false;
            activateDeathTimer = false;
            timer = deathTimer;
        }
        

        agentViewPortPosition = cam.WorldToViewportPoint(transform.position);
        
            if(agentViewPortPosition.x>0 || agentViewPortPosition.x<1 || agentViewPortPosition.y>0 || agentViewPortPosition.y<1)
            {
                hasEnteredScreen = true;
            }
        
        if (hasEnteredScreen)
        {
            if (agentViewPortPosition.x > 1)
            {
                activateDeathTimer = true;
            }
        }
    }
    

}