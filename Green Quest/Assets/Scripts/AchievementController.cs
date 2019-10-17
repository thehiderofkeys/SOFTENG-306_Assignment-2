using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    public static List<int> starsForLevels =  new List<int>() { 0, 0, 0 };
   // public Sprite achievedStar;
   // public Sprite notAchievedStar;
    public static AchievementController instance; 

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Updates how many stars the user has acheived for the level
    public static void UpdateStarsForLevel(int level, int starsAchieved)
    {
        starsForLevels[level - 1] = starsAchieved;
    }

    public List<int> GetStarsForLevels()
    {
        return starsForLevels; 
    }

}
