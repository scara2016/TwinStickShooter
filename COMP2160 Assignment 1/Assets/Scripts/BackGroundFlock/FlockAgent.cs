using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    private Collider2D agentCollider;
    Camera cam;
    public Collider2D AgentCollider
    {
        get
        {
            return agentCollider;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        
        if(cam.WorldToViewportPoint(transform.position).x > 1.1)
        {
            
            Reposition(cam);
        }
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
    public void Reposition(Camera cam)
    {
        
        transform.position = (Vector2)cam.ViewportToWorldPoint(new Vector2(-0.1f, Random.Range(0.0f, 1.0f)));
    }
}
