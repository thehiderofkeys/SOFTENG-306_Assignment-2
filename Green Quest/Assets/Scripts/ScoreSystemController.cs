using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystemController : MonoBehaviour
{
    private bool isComplete;
    public int level; 
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
        StarImages.level = level;
       
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
        Debug.Log("isCOmplete");
        return isComplete;
    }

    public List<Objective> GetObjectives()
    {
        return this.objectives;
    }


    public void CalculateStarsEarned()
    {
        int starsEarned = 0; 
        foreach(Objective o in objectives)
        {
            int count = 0; 
            if(o.GetCount() - o.GetTarget() == 0)
            {
                if(count <= 0)
                {
                    count = 0; 
                }
                
            }
            else if(o.GetMaxTarget() - o.GetCount() == 2)
            {
                if (count <= 1)
                {
                    count = 1;
                }
            }
            else if(o.GetMaxTarget() - o.GetCount() == 1)
            {
                if (count <= 2)
                {
                    count = 2;
                }
            }
            else if (o.GetMaxTarget() - o.GetCount() == 0)
            {
                if (count <= 3)
                {
                    count = 3;
                }
            }
            starsEarned = count; 
        }

        AchievementController.UpdateStarsForLevel(level, starsEarned); 
    }

}

[System.Serializable] 
public class Objective
{
    public int count = 0;
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

    public int GetMaxTarget()
    {
        return maxTarget;
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
