using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystemController : MonoBehaviour
{
    private bool isComplete;

    public List<Objective> objectives;
    public static ScoreSystemController instance;

   /* int count;
    Text scoreText;*/
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //count = 0;
        isComplete = false;
        //SetText(count);

       
    }

    // Update is called once per frame
    void Update()
    {

        int objectivesComplete = 0;

        for(int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i].GetTarget() <= objectives[i].GetCount())
            {
                objectivesComplete++;
            }
        }
        if (objectivesComplete == objectives.Count)
        {
            isComplete = true;
        }
    }

    /*public static void IncrementSwitchCount()
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
    }*/

    // Returns a boolean if the game is Complete.
    public bool IsComplete()
    {
        return isComplete;
    }

    public List<Objective> GetObjectives()
    {
        return this.objectives;
    }


  

}

[System.Serializable] 
public class Objective
{
    private int count = 0;
    public Text scoreText;
    public int target;
    public int maxTarget;

    public int GetTarget()
    {
        return this.target;
    }

    public int GetCount()
    {
        return count; 
    }

    public void IncrementCount()
    {
        // Call this method when a switch has been activated
        count++;
        SetText(count);
        //print("Increment");
    }

    // Decrement the count when the player hits it.
    public void DecrementCount()
    {
        count--;
        SetText(count);
    }

    void SetText(int score)
    {
        scoreText.text = score.ToString() + " / " + maxTarget.ToString();
       // if (score >= maxTarget)
      //  {
      //
       //     scoreText.text = "Complete!";
      //  }
    }
}
