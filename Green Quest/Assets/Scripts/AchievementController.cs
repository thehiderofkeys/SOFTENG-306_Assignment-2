using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    private int count;
    private bool isComplete;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
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

    public void IncrementSwitchCount()
    {
        // Call this method when a switch has been activated
        count++;
        SetText(count);
        //print("Increment");
    }

    public void DecrementSwitchCount()
    {
        count--;
        SetText(count);
    }

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
