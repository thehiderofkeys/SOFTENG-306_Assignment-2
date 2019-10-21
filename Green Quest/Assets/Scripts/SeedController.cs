using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeedController : MonoBehaviour
{
    // This is called when the user picks up the a seed.
    public void OnPickUp()
    {
        GameObject.FindGameObjectWithTag("Item").GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag("Item").GetComponent<SpriteRenderer>().enabled = true;
        Tree.SetTreeEnabled(true);
        Destroy(gameObject);
    }
}
