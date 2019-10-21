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
        // Code is "787898", user needs to input this in the right order without interruptions
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

            // Transform the player position to the end of the level
            player.transform.SetPositionAndRotation(endPosition.position, new Quaternion(0, 0, 0, 0));

            // Get the array of all level-related objects (taps, lights, enemies, trees)
            GameObject[] array = GameObject.FindGameObjectsWithTag("Switch");
            GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] treeArray = GameObject.FindGameObjectsWithTag("Tree");

            // Go through every tree
            foreach (GameObject tree in treeArray)
            {
                // Plant the tree by invoking the on event
                tree.GetComponent<InteractableController>().OnEvent.Invoke();
            }

            // Go through every bulldozer and invoke the on stomp event to crush them
            foreach (GameObject enemy in enemyArray)
            {
                if (enemy.GetComponent<Collider2D>().enabled)
                {
                    enemy.GetComponent<EnemyController>().OnStomped.Invoke();
                }

            }

            // Go through every single switch and tap of the level
            foreach (GameObject item in array)
            {
                // If the tap or light is sitll on
                if (item.GetComponent<InteractableController>().State)
                {
                    // Turn off the tap/switch
                    item.GetComponent<InteractableController>().OffEvent.Invoke();
                }

            }
        }
    }
}
