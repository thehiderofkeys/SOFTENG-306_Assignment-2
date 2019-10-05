using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueContainer : MonoBehaviour
{
    public TextAsset DialogFile;
    public Button NextButton;
    public Text DialogUI;
    public UnityEvent OnEnd;
    public DialogueEvent[] events;
    public DialogueCharacter[] characters;
    public string[] Dialogs;
    private int currLine = 0;
    void OnEnable()
    {
        Dialogs = System.Text.Encoding.Default.GetString(DialogFile.bytes).Split('\n');
        currLine = 0;
        Next();
    }
    public void Next()
    {
        if (currLine >= Dialogs.Length)
        {
            OnEnd.Invoke();
            return;
        }
        string id = ReplaceAllWhiteSpaces(Dialogs[currLine++]);
        if(string.Equals(id,"Event"))
        {

            foreach (DialogueCharacter character in characters)
            {
                character.CharacterImage.SetActive(false);
            }
            string eventName = ReplaceAllWhiteSpaces(Dialogs[currLine++]);
            foreach(DialogueEvent dialogueEvent in events){
                if(dialogueEvent.Name == eventName)
                {
                    NextButton.gameObject.SetActive(false);
                    dialogueEvent.onRead.Invoke();
                    StartCoroutine(PauseForEffect(dialogueEvent.Duration));
                }
            }
        }
        else
        {
            string Name = "";
            foreach(DialogueCharacter character in characters){
                character.CharacterImage.SetActive(string.Equals(character.id,id));
                Name = character.Name + ": ";
            }
            DialogUI.text = Name+Dialogs[currLine++];
        }
    }
    public IEnumerator PauseForEffect(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        NextButton.gameObject.SetActive(true);
        Next();
    }
    public static string ReplaceAllWhiteSpaces(string str)
    {
        return Regex.Replace(str, @"\s+", String.Empty);
    }
}
[System.Serializable]
public class DialogueEvent
{
    public string Name;
    public float Duration;
    public UnityEvent onRead;
}
[System.Serializable]
public class DialogueCharacter
{
    public string Name;
    public string id;
    public GameObject CharacterImage;
}
