using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from
public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    private float speedX = 2f;
    private float speedY = 2.5f;

    private Rigidbody2D rb;
    private Vector3 checkpoint;
    private Vector3 startPosition;
    // Start is called before the first frame update
    private ContactPoint2D[] points = new ContactPoint2D[20];
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
            velocity.x = 5f * inputX;
        if (inputY > 0.2 && isContact(Vector2.up)){
            velocity.y = 12f;
        }

        rb.velocity = velocity;

        //rb.velocity = velocity;
        //transform.Translate(velocity * Time.deltaTime);
    }

    bool isContact(Vector2 normal){
        int count = rb.GetContacts(points);
        for(int i=0;i < count; i++)
        {
            if (Vector2.Dot(points[i].normal,normal) > 0.9){
                return true;
            }
        }
        return false;
    }

}
