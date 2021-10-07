using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Transform flockTarget)
    {
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
            if (item.gameObject.CompareTag("FlockAgent"))
            {
                {
                    cohesionMove += (Vector2)item.position;
                }
            }
        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;
    }

}
