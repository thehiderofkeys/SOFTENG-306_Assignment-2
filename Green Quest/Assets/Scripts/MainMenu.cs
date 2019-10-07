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

    // The level selection scene - not used in first prototype as only one lvl
    public string newGameSceneName;
    public GameObject loadGameMenu;
    

  
    // Loads the first level ie a new game
    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    // Opens the level selection menu
    public void OpenLoadGameMenu()
    {
        loadGameMenu.SetActive(true);
    }

    // Closes the level selection menu
    public void ExitLoadGameMenu()
    {
        loadGameMenu.SetActive(false);
    }

    // Closes the application - only works on a compiled version of the game
    public void ExitGame()
    {
        Application.Quit(); 
    }

    // Loads level 2 - called in level selction memu
    public void LoadLevel2()
    {
        //SceneManager.LoadScene();
    }

    // Loads level 3 - called in level selction memu
    public void LoadLevel3()
    {
        //SceneManager.LoadScene();
    }
}
