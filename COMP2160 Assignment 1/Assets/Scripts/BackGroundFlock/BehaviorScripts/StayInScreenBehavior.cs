using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/StayInScreen")]
public class StayInScreenBehavior : FlockBehavior
{
    Vector2 agentWorldPosition;
    Vector2 agentViewPortPosition;
    Vector2 centerMove;
    public float centerPullForce;
    Camera cam;

    
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Transform flockTarget)
    {
        if(cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }
        agentWorldPosition = agent.transform.position;
        agentViewPortPosition = cam.WorldToViewportPoint(agentWorldPosition);
        if (agentViewPortPosition.x > 1)
        {
            centerMove.x = Vector2.left.x;
        }
        else if (agentViewPortPosition.x < 0)
        {
            centerMove.x = Vector2.right.x;
        }
        else
        {
            centerMove.x = 0;
        }
        if (agentViewPortPosition.y > 1)
        {
            centerMove.y = Vector2.down.y;
        }
        else if (agentViewPortPosition.y < 0)
        {
            centerMove.y = Vector2.up.y;
        }
        else
        {
            centerMove.y = 0;
        }
        return centerMove;

        
    }

 
}
