using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableController : MonoBehaviour
{
    public LayerMask playerLayer;
    private Collider2D collider2D;
    public Sprite newSprite;
    private Sprite oldSprite;
    private Sprite temp;
    private SpriteRenderer renderer;
    public UnityEvent OnEvent;
    public UnityEvent OffEvent;
    public bool State;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }


   
    
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Fire1") > 0)
        //{
        //    if (collider2D.IsTouchingLayers(playerLayer))
        //    {

        //        // Trigger light or something

        //    }
        //}
        if (collider2D.IsTouchingLayers(playerLayer))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (State)
                {
                    OffEvent.Invoke();
                }
                else
                {
                    OnEvent.Invoke();
                }
                State = !State;
            }
        }
    }

}
