using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller to enable Choi to throw the seed. 
public class ThrowController : MonoBehaviour
{
    public Transform Prefab;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float pickupTime;

    // Sets up the seedling
    private void Start()
    {
        sprite = GameObject.FindGameObjectWithTag("Item").GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // If the user preses the space bar then the user will throw the seeding. 
    private void Update()
    {
        if (Time.time - pickupTime > 0.25f && Input.GetKeyDown(KeyCode.Space))
        {
            sprite.enabled = false;
            Transform projectile = Instantiate(Prefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().initVelocity = new Vector2(PlayerController.instance.direction * 12f, 3f);
            projectile.GetComponent<Projectile>().enabled = true;
            RandomSpawnController.instance.SpawnGameObject();
        }
        if (!sprite.enabled)
        {
            pickupTime = Time.time;
        }
    }
}
