using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from
public class PlayerController : MonoBehaviour
{
   
    private float speedX = 2f;
    private float speedY = 2.5f;

    private Rigidbody2D rb;
    private Vector3 checkpoint;
    private Vector3 startPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        var movementX = inputX * speedX;
        rb.velocity = new Vector3(movementX, rb.velocity.y);

        //rb.AddForce(new Vector2(100, 0)); 
        

        //rb.velocity = velocity;
        //transform.Translate(velocity * Time.deltaTime);
    }

    bool isOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if (distance < DIST_FLOOR + DIST_THRESH)
            {
                return true;
            }
        }
        return false;
    }
}
