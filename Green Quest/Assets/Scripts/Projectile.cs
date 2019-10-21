using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    public UnityEvent OnCollide;
    public LayerMask TargetLayer;
    public Vector2 initVelocity;

    void Start()
    {
        // Set the velocity of the projectile, value changed in Unity
        GetComponent<Rigidbody2D>().velocity = initVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the projectile hits the layer or user then invoke method to 
        if (TargetLayer == (TargetLayer | 1 << collision.gameObject.layer))
        {
            OnCollide.Invoke();
        }
        // Destroy the projectile
        Destroy(gameObject);
    }
    public void StunBoss()
    {
        // Set the boss to invulnerable for 5 seconds
        BossController.instance.StartVolnurable(5);
    }
}
