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
        GetComponent<Rigidbody2D>().velocity = initVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (TargetLayer == (TargetLayer | 1 << collision.gameObject.layer))
        {
            OnCollide.Invoke();
        }
        Destroy(gameObject);
    }
    public void StunBoss()
    {
        BossController.instance.StartVolnurable(5);
    }
}
