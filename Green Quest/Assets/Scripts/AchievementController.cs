using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    public static List<int> starsForLevels = null;

    void Start()
    {
        if (starsForLevels == null)
        {
            InitStarsArray();
        }
    }

    void InitStarsArray()
    {
        starsForLevels = new List<int>() { 0, 0, 0 };
    }

    // Updates how many stars the user has acheived for the level
    void UpdateStarsForLevel(int level, int starsAchieved)
    {
        //starsForLevels[level - 1] = 
    }


}
