using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour{
    [System.Serializable]
    public class ParallaxElement{
        public Transform background;
        public float seperation;
    }
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
}
