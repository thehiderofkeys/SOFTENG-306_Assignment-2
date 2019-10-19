using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodeController : MonoBehaviour
{

    private string[] code;
    private int index;
    public GameObject player;
    public Transform endPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        code = new string[] { "7", "8", "7", "8", "9", "8" };
        index = 0;
    }


    // Updated every frame
    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(code[index]))
            {
                // Increment the index to check the next key in the sequence
                index++;
            }
            // Incorrect sequence, reset the index
            else
            {
                index = 0;
            }
        }

        // If the index = length of cheat code
        // it means the entered sequence is correct
        if (index == code.Length)
        {
            Debug.Log("Cheat code entered!");
            // Reset the index so this is only called once
            index = 0;

            player.transform.SetPositionAndRotation(endPosition.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
