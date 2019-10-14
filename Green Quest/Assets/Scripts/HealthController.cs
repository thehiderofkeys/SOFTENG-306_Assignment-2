using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    public static void LoseHeart(int heartsRemaining)
    {

       instance.livesImages[heartsRemaining].sprite = instance.EmptyHeart;

    }


}
