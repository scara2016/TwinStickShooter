using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/MoveTowardsTarget")]
public class MoveTowardsTargetBehaviour : FlockBehavior
{
    public float speed = 5f;
    public enum MovementType
    { 
        TargetX,
        TargetY,
        TargetBoth
    }
    public MovementType movementType; 
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Transform flockTarget)
    {
        Vector2 targetedMove;
        targetedMove = (flockTarget.position - agent.transform.position).normalized;
        switch (movementType)
        {
            case MovementType.TargetX:
                targetedMove = flockTarget.position - agent.transform.position;
                return new Vector2(targetedMove.x * speed, 0);
            case MovementType.TargetY:
                targetedMove = flockTarget.position - agent.transform.position;
                return new Vector2(0, targetedMove.y * speed);
            case MovementType.TargetBoth:
                targetedMove = flockTarget.position - agent.transform.position;
                return targetedMove * speed;
            default:
                return Vector2.zero;
        }
    }

   
}
