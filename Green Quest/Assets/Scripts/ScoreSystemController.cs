using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystemController : MonoBehaviour
{
    private int count;
    private bool isComplete;
    public Text scoreText;
    public static ScoreSystemController instance;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        count = 0;
        isComplete = false;
        SetText(count);
        

       
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 10)
        {
            isComplete = true;
            print("The level is complete");
            // The player has completed the level

        }
    }

    public static void IncrementSwitchCount()
    {
        // Call this method when a switch has been activated
        instance.count++;
        instance.SetText(instance.count);
        //print("Increment");
    }

    // Decrement the count when the player hits it.
    public static void DecrementSwitchCount()
    {
        instance.count--;
        instance.SetText(instance.count);
    }

    // Returns a boolean if the game is Complete.
    public bool IsComplete()
    {
        return isComplete;
    }


    void SetText(int score)
    {
        scoreText.text = score.ToString() + " / 10";
        if (score >= 10)
        {

            scoreText.text = "Complete!";
        }
    }
}
