using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour{
    [System.Serializable]
    public class ParallaxElement{
        public Transform background;
        public float seperation;
    }
    public UnityEvent OnSuccess;
    public UnityEvent OnFail;


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

   
    public void ExitMenu()
    {
        if (GetComponent<AchievementController>().IsComplete())
        {
            OnSuccess.Invoke();
        }
        else
        {
            OnFail.Invoke();
        }
   
    }
    public void LoadScene(string SceneString)
    {
        SceneManager.LoadScene(SceneString);
    }

    public void Respawn()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");

        if (obj.Length > 0)
        {
            obj[0].transform.SetPositionAndRotation(new Vector3(-3, -1, 0), new Quaternion(0,0,0,0));
        }
    }
   

}
