using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Handles the interaction that the character will have when pressing the switch.
public class InteractableController : MonoBehaviour
{
    public LayerMask playerLayer;
    private Collider2D collider2D;
    //public Sprite newSprite;
    private Sprite oldSprite;
    private Sprite temp;
    private SpriteRenderer renderer;
    public UnityEvent OnEvent;
    public UnityEvent OffEvent;
    public bool State;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }


   
    
    // Update is called once per frame
    void Update()
    {
        // Check for layer overlap between the player and the switch/tap
        if (collider2D.IsTouchingLayers(playerLayer))
        {
            // Check if the player pressed the spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (State) // Just a simple if statement that will flip the state to be on or off.
                {
                    // Trigger the off event to turn off the light/tap
                    OffEvent.Invoke();
                }
                else
                {
                    // Trigger the on event to turn the light/tap back on
                    OnEvent.Invoke();
                }
                State = !State;
            }
        }
    }

    // Increment the score by one if the player turns off a light/tap
    public void IncrementScore(int objectiveIndex)
    {
        // Call the ScoreSystem controller to change the counts
        List<Objective> objectives = ScoreSystemController.instance.GetObjectives();
        Objective objective = objectives[objectiveIndex];
        objective.IncrementCount();
        objectives[objectiveIndex] = objective;

    }

    // Increment the score by one if the player turns a light/tap back on
    public void DecrementScore(int objectiveIndex)
    {
        List<Objective> objectives = ScoreSystemController.instance.GetObjectives();
        Objective objective = objectives[objectiveIndex];
        objective.DecrementCount();
        objectives[objectiveIndex] = objective;
    }
}
