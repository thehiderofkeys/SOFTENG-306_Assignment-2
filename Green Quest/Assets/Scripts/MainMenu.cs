using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Main menu button
    public Button newGameButton;
    public Button loadGameButton;
    public Button exitGameButton;


    // Level selection menu buttons
    public Button exitLoadGameButton;
    public Button selectLevel1Button;
    public Button selectLevel2Button;
    public Button selectLevel3Button;

    public string newGameSceneName;
    public GameObject loadGameMenu;
    

  
    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    public void OpenLoadGameMenu()
    {
        loadGameMenu.SetActive(true);
    }

    public void ExitLoadGameMenu()
    {
        loadGameMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }

    public void LoadLevel2()
    {
        //SceneManager.LoadScene();
    }

    public void LoadLevel3()
    {
        //SceneManager.LoadScene();
    }
}
