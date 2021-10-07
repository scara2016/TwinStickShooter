using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Allignment")]
public class AllignmentBehaviour : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Transform flockTarget)
    {
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

Vector2 allignmentMove = Vector2.zero;
        foreach(Transform item in context)
        {
            allignmentMove += (Vector2) item.transform.up;
        }
        allignmentMove /= context.Count;

       
        return allignmentMove;
    }

}
