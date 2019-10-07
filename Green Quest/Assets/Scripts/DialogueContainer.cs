using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/**
 * DialogueContainer: Procedually generates Cuscenes from a .txt file
 * Each dialgue entry is 2 lines. 
 *      - 1 line to encode the type of dialogue, ie Event or a specifc Character speaking (Can be null without any visuals).
 *      - 1 line for the name of the event to callback or the text to display for the Character speaking.
 */
public class DialogueContainer : MonoBehaviour
{
    public TextAsset DialogFile; //The text file containing the dialog data
    public GameObject DialoguePanel; //Text Panel Under the player avatars
    public Text DialogUI; //Text UI Element
    public UnityEvent OnStart; //Things to happen before the cutscene start
    public UnityEvent OnEnd; //Things to happen after the cutscene
    public DialogueEvent[] events; //List of events in the dialogue
    public DialogueCharacter[] characters; //The Character visuals to map to the dialogue
    private string[] Dialogs;
    private int currLine = 0;

    /**
     * Called when the cutscen is shown. Calls the events to happen before the cutscene start.
     */
    void OnEnable()
    {
        OnStart.Invoke();
        Dialogs = System.Text.Encoding.Default.GetString(DialogFile.bytes).Split('\n');
        currLine = 0;
        Next();//Show the first dialogue
    }
    /**
     * Show the Next Dialogue.
     */
    public void Next()
    {
        if (currLine >= Dialogs.Length)
        {
            OnEnd.Invoke(); //If the end of the dialog file is reached, run the events to happen after the cutscene
            return;
        }
        string id = ReplaceAllWhiteSpaces(Dialogs[currLine++]); //Remove Whitespaces for easier comparisons.
        if(string.Equals(id,"Event"))
        {
            //If the next dialogue action is an event
            foreach (DialogueCharacter character in characters)
            {
                character.CharacterImage.SetActive(false); //Turn off character visuals
            }
            string eventName = ReplaceAllWhiteSpaces(Dialogs[currLine++]); //Get the event to be called
            foreach(DialogueEvent dialogueEvent in events){
                if(dialogueEvent.Name == eventName)
                {
                    dialogueEvent.onRead.Invoke(); //Call the dialgue event
                    StartCoroutine(PauseForEffect(dialogueEvent.Duration)); //Wait for the event to finish before showing next event
                    return;
                }
            }
            Debug.LogError("EVENT NOT FOUND"); //If the event matching the name cannot be found throw errors in the console
            Next(); //skip the event
        }
        else //If the dialogue action is a character speaking
        {
            DialoguePanel.SetActive(true); //make sure to show the dialgue captions
            string Name = ""; 
            foreach(DialogueCharacter character in characters){
                character.CharacterImage.SetActive(string.Equals(character.id,id)); //Show the appropriate character visuals and hide others
                if(string.Equals(character.id, id))
                    Name = character.Name + ": "; //Set character Prefix
            }
            DialogUI.text = Name+Dialogs[currLine++].Replace("$NAME$","Choi"); //Show the speach
        }
    }
    public IEnumerator PauseForEffect(float seconds)
    {
        yield return new WaitForSeconds(seconds); //wait for n seconds
        Next(); //show the next dialogue
    }
    public static string ReplaceAllWhiteSpaces(string str)
    {
        return Regex.Replace(str, @"\s+", String.Empty); //regex expression to remove all whitespaces
    }
}
[System.Serializable]
public class DialogueEvent //Dialogue Event Class. Data Class to hold fields. May hold functions in the future.
{
    public string Name; //Key to include in the dialogue text file
    public float Duration; //How long to pause before showing next dialogue
    public UnityEvent onRead; //Methods to call back 
}
[System.Serializable]
public class DialogueCharacter //Dialogue Character Class. Data Class to hold fields. May hold functions in the future.
{
    public string Name; //Name to display
    public string id; //Key to include in the dialogue text file
    public GameObject CharacterImage; //Character visuals to show
}
