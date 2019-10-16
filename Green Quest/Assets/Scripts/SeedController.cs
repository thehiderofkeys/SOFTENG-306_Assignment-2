using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeedController : MonoBehaviour
{
    public void OnPickUp()
    {
        Tree.SetTreeEnabled(true);
        Destroy(gameObject);
    }
}
