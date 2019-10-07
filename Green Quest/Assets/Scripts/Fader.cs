using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Class to enable fade in and out to black Coroutines to be started from UnityEvents
 */
public class Fader : MonoBehaviour {
    public float opacity; //current opacity, Read only
    public Image image; //The image object selected Read only.

    public void StartFadeIn(float speed) {
        if(image == null) //Set the image if not already set.
            image = GetComponent<Image>();
        StartCoroutine(FadeIn(speed)); //start fadeing in
    }

    public void StartFadeOut(float speed) {
        if (image == null) // set the image if not already set.
            image = GetComponent<Image>();
        StartCoroutine(FadeOut(speed)); //start fading out
    }
    private IEnumerator FadeIn(float speed) {
        for(opacity = 1; opacity > 0f; opacity -= Time.deltaTime / speed) {
            image.color = new Color(0, 0, 0, opacity); //increase the opacity.
            yield return null; //release CPU time to prevent hogging of process
        }
    }

    private IEnumerator FadeOut(float speed) {
        for (opacity = 0; opacity < 1f; opacity += Time.deltaTime / speed) {
            image.color = new Color(0, 0, 0, opacity); //increase the opacity
            yield return null; //release CPU time to prevent hogging of process
        }
    }
}
