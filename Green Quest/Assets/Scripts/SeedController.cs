using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeedController : MonoBehaviour
{
    public void OnPickUp()
    {
        GameObject.FindGameObjectWithTag("Item").GetComponent<SpriteRenderer>().enabled = true;
        Tree.SetTreeEnabled(true);
        Destroy(gameObject);
    }
}
