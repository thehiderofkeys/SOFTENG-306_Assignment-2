using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button newGameButton;
    public Button loadGameButton;
    public Button exitGameButton;

    public string newGameSceneName;
    public GameObject loadGameMenu;
    

    public void Awake()
    {   

        newGameButton.onClick.AddListener(NewGame);
        loadGameButton.onClick.AddListener(OpenLoadGameMenu);
        exitGameButton.onClick.AddListener(ExitGame);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

  

    public void OpenLoadGameMenu()
    {
        loadGameMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }
}
