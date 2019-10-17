using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitController : MonoBehaviour
{

    // Buttons in the exit screen
    public Button nextLevel;
    public Button retry;
    public Button home;

    // Screen names to transition to for each button
    //public string nextScene;
   // public string retryScene;
    public string homeScene;

    // Changes to next level
    public void ChangeNextScene()
    {
        int level = StarImages.level;
        string nextScene = "Level" + level.ToString();
        SceneManager.LoadScene(nextScene); 
    }

    // Reloads the same scene
    public void ChangeRetryScene()
    {
        int level = StarImages.level;
        string retryScene = "Level" + level.ToString(); 
        SceneManager.LoadScene(retryScene);
    }

    // Returns player to main menu screen
    public void ChangeHomeScene()
    {
        SceneManager.LoadScene(homeScene);
    }

}
