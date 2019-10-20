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
    Vector2 position;

    public float offsetX;
    public float offsetY;
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
        position = player.position + new Vector3((Random.value-0.5f) * offsetX, offsetY);
        // Gets the random position of the drop. 
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);

        if (hit && !Physics2D.OverlapBox(position,new Vector2(1,1), 0))
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
            Instantiate(seedlingPrefab, position, transform.rotation);
        }
        recursiveCount = 0;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(position, position + 10 * Vector2.down);
    }
}
