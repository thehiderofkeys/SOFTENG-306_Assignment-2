using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code modified from
public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    private float speedX = 2f;
    private float speedY = 2.5f;
    public Animator animator;
    private bool jump = false;
    private bool fall = false;
    private int direction = 1;
    private bool stunned = false;
    public GameObject player;
    public string exitGameScene;

    private int remainingLives = 3;
    private int totalLives = 3;

    private Rigidbody2D rb;
    private Vector3 checkpoint;
    private Vector3 startPosition;
    // Start is called before the first frame update
    private ContactPoint2D[] points = new ContactPoint2D[20];
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        jump = false;
        fall = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        if (!isContact(new Vector2(-inputX,0).normalized)&&Mathf.Abs(inputX)>0.2){
            velocity.x = 5f * inputX;
        }
        if (inputY > 0.2 && isContact(Vector2.up)){
            velocity.y = 12f;
        }

      
        // Going right
        if (velocity.x > 0.1) 
        {
            direction = 1;
        }
        // Going left
        if (velocity.x < -0.1) 
        {
            direction = -1; 
        }

        // Set the X scale of the player which sets the direction the character is facing
        player.transform.localScale = new Vector3(direction, 1, 1);

       
        if (velocity.y > 0.1)
        {
            // if the player's vertical velocity is greater than 0
            // it means the player is jumping
            jump = true;
            fall = false;
        } else if (velocity.y < -0.1)
        {
            // if the player's vertical velocity is less than -0.1
            // it means the player is falling
            jump = false;
            fall = true;
        } else
        {
            jump = false;
            fall = false;
        }


        if (!stunned)
        {
            rb.velocity = velocity;
        }

        animator.SetFloat("Speed", Mathf.Abs(velocity.x));
        animator.SetBool("Jump", jump);
        animator.SetBool("Fall", fall);
    }
    public void SetStunned(float duration)
    {
        StartCoroutine(Stun(duration));
    }
    public void SetInvincible(float duration)
    {
        StartCoroutine(Invincible(duration));
    }
    private IEnumerator Stun(float duration)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        stunned = true;
        yield return new WaitForSeconds(0.2f);
        renderer.color = Color.white;
        yield return new WaitForSeconds(duration);
        stunned = false;
    }
    private IEnumerator Invincible(float duration)
    {
        gameObject.layer = LayerMask.NameToLayer("IgnoreEnemy");
        Color currColor;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i*0.4 < duration; i++)
        {
            currColor = renderer.color;
            currColor.a = 0.8f;
            renderer.color = currColor;
            yield return new WaitForSeconds(0.2f);
            currColor = renderer.color;
            currColor.a = 1f;
            renderer.color = currColor;
            yield return new WaitForSeconds(0.2f);
        }
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    /**Checks if player is hitting something in a certain direction
     *     Vector2 normal - the desired direction of contact
     */
    GameObject isContact(Vector2 normal){
        int count = rb.GetContacts(points); //get all the contact points.
        for(int i=0;i < count; i++) //iterate through contact points
        {
            if (Vector2.Dot(points[i].normal,normal) > 0.9){ //if the contact normal 90% in the same direction as the desired direction
                return points[i].otherCollider.gameObject;
            }
        }
        return null;
    }

    public void Respawn()
    {
            if (LivesRemain())
            {
                transform.SetPositionAndRotation(new Vector3(-3, -1, 0), new Quaternion(0, 0, 0, 0));
            }
            DecrementLives();
    }

    /***
     Helper function that checks if the player should lose a life
    ***/
    public void DecrementLives()
    {
        if ( remainingLives > 1)
        {
            remainingLives--;
            HealthController.LoseHeart(remainingLives);
        }
        else
        {
            SceneManager.LoadScene(exitGameScene);
        }

    }

    /***
     * 
     ***/
     public bool LivesRemain()
    {
        if (remainingLives > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /***
     * Helper function that checks if the player is able to gain a life and increments it if they can
     ***/
    public void IncrementLives()
    {
        if( remainingLives < totalLives)
        {
            remainingLives++;
        }
    }

}
