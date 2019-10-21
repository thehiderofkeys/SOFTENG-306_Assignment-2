using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to populate the HUD with player lives 
public class HealthController : MonoBehaviour
{


    public List<Image> livesImages;
    public Sprite FilledHeart;
    public Sprite EmptyHeart;
    private static HealthController instance;
    void Start()
    {
        instance = this;
    }
    
    // This method is called when the player loses a life to update the hearts on the HUD
    public static void LoseHeart(int heartsRemaining)
    {
        instance.GetComponent<AudioSource>().Play();
        instance.livesImages[heartsRemaining].sprite = instance.EmptyHeart;

    }


}
