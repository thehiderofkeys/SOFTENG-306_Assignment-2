using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To create the camera tracking motion in the game.
public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Finds the position of the camera relative to the character. 
        Vector3 offSet = transform.position - player.position;

        // This limits the range of the camera. 
        offSet.x = Mathf.Clamp(offSet.x, minX, maxX);
        offSet.y = Mathf.Clamp(offSet.y, minY, maxY);

        // Changes the camera position to the new position.s
        transform.position = player.position + offSet;
    }
}
