using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class is used to populate the HUD images for boss health in level 3
public class BossHealthController : MonoBehaviour
{


    public List<Image> bossHealthImages;
    public Sprite FilledSkull;
    public Sprite EmptySkull;
    public int numLivesReamining;
    public static BossHealthController instance;


    void Start()
    {
        instance = this;
        instance.numLivesReamining = 6;
    }


    // This method is called to update the HUD to display how many lives the boss has reamining
    public void LoseLife()
    {
        
        instance.numLivesReamining--;

        List<Objective> objectives = ScoreSystemController.instance.GetObjectives();
        Objective objective = objectives[1];
        objective.IncrementCount();
        objectives[1] = objective;

        instance.bossHealthImages[instance.numLivesReamining].sprite = instance.EmptySkull;
    }

}
