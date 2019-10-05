using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AchievementController))]
public class Level : MonoBehaviour{
    [System.Serializable]
    public class ParallaxElement{
        public Transform background;
        public float seperation;
    }
    public string successExitScreen;
    public string failExitScreen;
    public Level level;

    public ParallaxElement[] parallaxElements;
    private Vector3 cameraStartPosition;
    // Start is called before the first frame update
    void Start(){
        cameraStartPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update() {
        Vector3 diff = Camera.main.transform.position - cameraStartPosition;
        foreach(ParallaxElement parallaxElement in parallaxElements){
            parallaxElement.background.localPosition = diff * parallaxElement.seperation;
        }
    }

   
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Player's tag is player, so when the player collides with this object, it will load the exit script.
        if (collider.gameObject.tag == "Player")
        {
            if (GetComponent<AchievementController>().IsComplete())
            {
                SceneManager.LoadScene(successExitScreen);
                print("yessssss");
            }
        }
    }
}
