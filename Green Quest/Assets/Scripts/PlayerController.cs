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

        if (!isContact(new Vector2(-inputX,0).normalized)){
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
        } 

        if (velocity.y < -0.1)
        {
            // if the player's vertical velocity is less than -0.1
            // it means the player is falling
            jump = false;
            fall = true;
        }
        else
        {
            fall = false;
        }



        rb.velocity = velocity;

        animator.SetFloat("Speed", Mathf.Abs(velocity.x));
        animator.SetBool("Jump", jump);
        animator.SetBool("Fall", fall);
    }
    /**Checks if player is hitting something in a certain direction
     *     Vector2 normal - the desired direction of contact
     */
    bool isContact(Vector2 normal){
        int count = rb.GetContacts(points); //get all the contact points.
        for(int i=0;i < count; i++) //iterate through contact points
        {
            if (Vector2.Dot(points[i].normal,normal) > 0.9){ //if the contact normal 90% in the same direction as the desired direction
                return true;
            }
        }
        return false;
    }

    public void Respawn()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");

        if (obj.Length > 0)
        {
            if (LivesRemain())
            {
                obj[0].transform.SetPositionAndRotation(new Vector3(-3, -1, 0), new Quaternion(0, 0, 0, 0));
                DecrementLives();
            }
            else
            {
                SceneManager.LoadScene(exitGameScene);
            }
        }
    }

    /***
     Helper function that checks if the player should lose a life
    ***/
    public void DecrementLives()
    {
        if ( remainingLives > 0)
        {
            remainingLives--;
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
