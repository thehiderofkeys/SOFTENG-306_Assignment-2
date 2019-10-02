using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector3 offSet = transform.position - player.position;
        offSet.x = Mathf.Clamp(offSet.x, minX, maxX);
        offSet.y = Mathf.Clamp(offSet.y, minY, maxY);

        transform.position = player.position + offSet;
    }
}
