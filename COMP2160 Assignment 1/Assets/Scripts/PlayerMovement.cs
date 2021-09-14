using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    private bool underLeft = true;
    private bool underTop = true;
    private bool underRight = true;
    private bool underDown = true;
    private GameManager gameManager;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.GameStarted();
    }

    // Update is called once per frame
    void Update()
    {
        
        float up = Input.GetAxis(InputAxes.Up);
        float down = Input.GetAxis(InputAxes.Down);
        float left = Input.GetAxis(InputAxes.Left);
        float right = Input.GetAxis(InputAxes.Right);
        cameraEdgeChecker();
        if (Input.GetButton(InputAxes.Up))
        {   
            if(underTop)
            transform.Translate(up * speed * Vector2.up * Time.deltaTime);
        }
        if (Input.GetButton(InputAxes.Down))
        {
            if(underDown)
            transform.Translate(down * speed * Vector2.down * Time.deltaTime);
        }
        if (Input.GetButton(InputAxes.Left))
        {
            if(underLeft)
            transform.Translate(left * speed * Vector2.left * Time.deltaTime);
        }
        if (Input.GetButton(InputAxes.Right))
        {
            if(underRight)
            transform.Translate(right * speed * Vector2.right * Time.deltaTime);
        }
    }
    
    // Convert Player Pos to ViewportPoint and check if out of screen
    private void cameraEdgeChecker()
    {
       

        Vector2 viewPosLeft = cam.WorldToViewportPoint(this.transform.position+(new Vector3(-0.5f,0,0)));
        if (viewPosLeft.x < 0)
        {
            underLeft = false;
        }
        else
        {
            underLeft = true;
        }
        Vector2 viewPosRight = cam.WorldToViewportPoint(this.transform.position + (new Vector3(0.5f, 0, 0)));
        if (viewPosRight.x > 1)
        {
            underRight = false;
        }
        else
        {
            underRight = true;
        }
        Vector2 viewPosUp = cam.WorldToViewportPoint(this.transform.position + (new Vector3(0, 0.5f, 0)));
        if (viewPosUp.y > 1)
        {
            underTop = false;
        }
        else
        {
            underTop = true;
        }
        Vector2 viewPosDown = cam.WorldToViewportPoint(this.transform.position + (new Vector3(0, -0.5f, 0)));
        if (viewPosDown.y < 0)
        {
            underDown = false;
        }
        else
        {
            underDown = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(typeof(Coin), out Component component))
        {
            gameManager.GameEnded();
            this.gameObject.SetActive(false);
        }
    }
}
