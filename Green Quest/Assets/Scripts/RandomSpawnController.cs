using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnController : MonoBehaviour
{

    // Game objs to instantiate
    public GameObject seedlingPrefab;
    public Transform player;
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
    public LayerMask layerMask;
    Vector2 position;

    public float offsetX;
    public float spawnHeight;
    public static RandomSpawnController instance;
    private int recursiveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SpawnGameObject()
    {
        Debug.Log("In Spawn game obj");
        float playerPositionX = player.position.x;
        float playerPositionY = player.position.y;
        position = new Vector3((Random.value-0.5f) * offsetX + player.position.x, spawnHeight);
        // Gets the random position of the drop. 
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down,100f, layerMask);

        if (hit && !Physics2D.OverlapBox(position,new Vector2(1,1), 0, layerMask))
        {
            Instantiate(seedlingPrefab, position, transform.rotation);
            return;
        }
        else if(recursiveCount < 10)
        {
            recursiveCount++;
            SpawnGameObject(); //retry
        }
        else
        {
            Debug.LogError("Failed to do Random Spawn after 10 tries");
            Instantiate(seedlingPrefab, position, transform.rotation);
        }
        recursiveCount = 0;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(position, position + 10 * Vector2.down);
    }
}
