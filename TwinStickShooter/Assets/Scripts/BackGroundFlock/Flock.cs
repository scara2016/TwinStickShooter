using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Transform flockTarget;
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;
    private Camera cam;
    private PlayerMovement player;

    [Range(10, 1000)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius
    {
        get
        {
            return squareAvoidanceRadius;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        cam = FindObjectOfType<Camera>();
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * squareAvoidanceRadius * squareAvoidanceRadius;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                (Vector2)cam.ViewportToWorldPoint(new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f))),
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent" + i;
            agents.Add(newAgent);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector2 move = behavior.CalculateMove(agent, context, this, flockTarget);
            move *= driveFactor;
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
            if (agents.Count < startingCount)
            {
                FlockAgent newAgent = Instantiate(
                 agentPrefab,
                 (Vector2)cam.ViewportToWorldPoint(new Vector2(-0.5f, Random.Range(0.0f, 1.0f))),
                 Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                 transform
                 );
                newAgent.name = "Agent" + agents.Count+1;
                agents.Add(newAgent);
            }
        }
    }


    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach(Collider2D c in contextColliders)
        {
            if(c!= agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
    
    

    
}
