using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour
{


    public List<Image> bossHealthImages;
    public Sprite FilledSkull;
    public Sprite EmptySkull;
    private int numLivesReamining;
    private static BossHealthController instance;


    void Start()
    {
        instance = this;
        instance.numLivesReamining = 6;
    }


    public void LoseLife()
    {
        instance.numLivesReamining--;
        instance.bossHealthImages[instance.numLivesReamining].sprite = instance.EmptySkull;
    }

}
