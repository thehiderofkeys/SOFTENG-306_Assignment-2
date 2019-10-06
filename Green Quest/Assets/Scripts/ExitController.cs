using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitController : MonoBehaviour
{

    public Button nextLevel;
    public Button retry;
    public Button home;
    public string nextScene;
    public string retryScene;
    public string homeScene;

    public void ChangeNextScene()
    {
        SceneManager.LoadScene(nextScene); 
    }

    public void ChangeRetryScene()
    {
        SceneManager.LoadScene(retryScene);
    }

    public void ChangeHomeScene()
    {
        SceneManager.LoadScene(homeScene);
    }

}
