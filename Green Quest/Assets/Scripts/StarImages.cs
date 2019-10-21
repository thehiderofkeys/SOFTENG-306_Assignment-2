using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the UI class for the achievement stars that appear in each successful exit menu
public class StarImages : MonoBehaviour
{
    public Sprite achievedStar;
    public Sprite notAchievedStar;
    public List<Image> starImages;
    public static StarImages instance;
    public static int level; 
    // Start is called before the first frame update
    void Start()
    {
        //Setting up singleton
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this; 
        
        List<int> starsForLevels = AchievementController.instance.GetStarsForLevels();
       
        SetStars(starsForLevels[level - 1]); 
    }

    //Setting number of stars in exit screen
    public static void SetStars(int starsAchieved)
    {
        
        for (int i = 0; i < starsAchieved; i++)
        {
            instance.starImages[i].sprite = instance.achievedStar;
        }
    }
}
