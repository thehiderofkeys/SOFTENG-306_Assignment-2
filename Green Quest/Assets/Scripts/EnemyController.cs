using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code modified from
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private ContactPoint2D[] points = new ContactPoint2D[20];
    private int direction = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        GameObject hit = isContact(new Vector2(-direction, 0).normalized);
        if (!hit)
        {
            velocity.x = 5f * direction;
        }
        else if(hit.GetComponent<PlayerController>())
        {
            PlayerController player = hit.GetComponent<PlayerController>();
            player.SetStunned(1);
            player.SetInvincible(5);
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(direction * 12f, 12f);
        }
        else
        {
            direction *= -1;
        }

        // Set the X scale of the player which sets the direction the character is facing
        transform.localScale = new Vector3(direction, 1, 1);
        rb.velocity = velocity;
    }
    /**Checks if player is hitting something in a certain direction
     *     Vector2 normal - the desired direction of contact
     */
    GameObject isContact(Vector2 normal)
    {
        int count = rb.GetContacts(points); //get all the contact points.
        for (int i = 0; i < count; i++) //iterate through contact points
        {
            if (Vector2.Dot(points[i].normal, normal) > 0.9)
            { //if the contact normal 90% in the same direction as the desired direction
                return points[i].collider.gameObject;
            }
        }
        return null;
    }
}
