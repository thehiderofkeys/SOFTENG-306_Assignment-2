using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorial;

    // Update is called once per frame
    void Update()
    {

        // Check if the player has pressed any key
        if (Input.anyKeyDown)
        {
            // If so then dismiss the on-screen tutorial 
            tutorial.SetActive(false);
        }
    }
}
