using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is in charge of the logic for the scoring system
public class ScoreSystemController : MonoBehaviour
{
    private bool isComplete;
    public int level; 
    public List<Objective> objectives;
    public static ScoreSystemController instance;
    

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

        
    }


    // Returns a boolean if the game is Complete.
    public bool IsComplete()
    {
        int objectivesComplete = 0;

        for (int i = 0; i < objectives.Count; i++)
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
        
        return isComplete;
    }

    public List<Objective> GetObjectives()
    {
        return this.objectives;
    }

    //Calculates the number of stars earned for each level
    public void CalculateStarsEarned()
    {
        int starsEarned = 0;
        int count = 100; 
        foreach(Objective o in objectives)
        {
               
            
            if(o.GetMaxTarget() - o.GetCount() == 3)
            {   
                if(count == 100)
                {
                    count = 0; 
                }
                else if(count >= 0)
                {
                    
                    count = 0;
                    
                }
                
            }
            else if(o.GetMaxTarget() - o.GetCount() == 2)
            {
                if(count == 100)
                {
                    count = 1; 
                }
                else if (count >= 1)
                {
                   
                    count = 1;
                    
                }
            }
            else if(o.GetMaxTarget() - o.GetCount() == 1)
            {
                if(count == 100)
                {
                    count = 2; 
                }
                if (count >= 2)
                {
                    
                    count = 2;
                    
                }
            }
            else if (o.GetMaxTarget() - o.GetCount() == 0)
            {
                if(count == 100)
                {
                    count = 3; 
                }
                if (count >= 3)
                {
                    
                    count = 3;
                    
                }
            }
            starsEarned = count; 
        }
        

        AchievementController.UpdateStarsForLevel(level, starsEarned); 
    }

}

//Objective class represents an objective the user needs to complete, for example: lightswitches to turn off or trees to plant
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
       
    }
}
