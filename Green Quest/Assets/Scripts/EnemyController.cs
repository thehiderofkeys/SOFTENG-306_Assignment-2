using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Code modified from
public class EnemyController : MonoBehaviour
{
    public UnityEvent OnStomped;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private ContactPoint2D[] points = new ContactPoint2D[20];
    private int direction = 1;
    private float lastHit = -1;
    private float lastStomp = -1;
    public bool Invincible;
    public bool stunned = false;
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
            if(!stunned)
                velocity.x = 5f * direction;
        }
        else if(hit.GetComponent<PlayerController>())
        {
            PlayerController player = hit.GetComponent<PlayerController>();
            HitPlayer(new Vector2(direction * 12f, 12f));
        }
        else
        {
            Flip();
        }
        hit = isContact(Vector2.down);
        if(hit && hit.GetComponent<PlayerController>())
        {
            if (Invincible)
            {
                HitPlayer(new Vector2(direction * 12f, 12f));
            }
            else
            {
                if (lastStomp < 0 || Time.time - lastStomp > 5f)
                {
                    lastStomp = Time.time;
                    GetComponent<AudioSource>().Play();
                    OnStomped.Invoke();
                }
            }
        }
        // Set the X scale of the player which sets the direction the character is facing
        transform.localScale = new Vector3(direction, 1, 1);
        rb.velocity = velocity;
    }
    public void Flip()
    { 
        direction *= -1;
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
    public void LaunchPlayer(Vector2 launchDir)
    {
        PlayerController player = PlayerController.instance;
        player.SetStunned(1);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = launchDir;
    }
    public void HitPlayer(Vector2 launchDir)
    {
        PlayerController player = PlayerController.instance;
        if (lastHit < 0 || Time.time - lastHit > 0.5)
        {
            lastHit = Time.time;
            LaunchPlayer(launchDir);
            player.SetInvincible(5);
            player.DecrementLives();
        }
    }
    public void HitPlayer()
    {
        HitPlayer(12*Vector2.up);
    }
}
