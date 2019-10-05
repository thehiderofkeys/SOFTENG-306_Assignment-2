using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionHandler : MonoBehaviour
{
    public UnityEvent colliderEvent;
    public Collider2D collider;
    public LayerMask playerLayer;


    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            colliderEvent.Invoke();
        }
    }
}
