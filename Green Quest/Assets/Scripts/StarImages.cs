using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this; 
        
        List<int> starsForLevels = AchievementController.instance.GetStarsForLevels();
        Debug.Log(starsForLevels);
        SetStars(starsForLevels[level - 1]); 
    }

    public static void SetStars(int starsAchieved)
    {
        for (int i = 0; i < starsAchieved; i++)
        {
            instance.starImages[i].sprite = instance.achievedStar;
        }
    }
}
