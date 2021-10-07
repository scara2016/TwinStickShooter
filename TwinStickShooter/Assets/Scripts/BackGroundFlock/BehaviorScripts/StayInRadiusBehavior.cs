using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/StayInRadius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector2 center;
    public float radius = 15f;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Transform flockTarget)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if(t < 0.9f)
        {
            return Vector2.zero;
        }
        return centerOffset * t * t;
    }

   
}
