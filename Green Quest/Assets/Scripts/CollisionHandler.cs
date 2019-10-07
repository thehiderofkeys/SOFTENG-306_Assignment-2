using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionHandler : MonoBehaviour
{
    // These fields are used when the player collides with a collider to trigger a respawn or exit game transition
    public UnityEvent colliderEvent;
    public Collider2D collider;
    public LayerMask playerLayer;



    // Method that is called when ANY 2 box colliders hit
    public void OnTriggerEnter2D(Collider2D collider)
    {
        // We invoke events when its the player collider that hit.
        if (collider.gameObject.tag == "Player")
        {
            colliderEvent.Invoke();
        }
    }
}
