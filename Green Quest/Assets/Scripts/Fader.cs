using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fader : MonoBehaviour {
    public float opacity;
    public Image image;

    public void StartFadeIn(float speed) {
        if(image == null)
            image = GetComponent<Image>();
        StartCoroutine(FadeIn(speed));
    }

    public void StartFadeOut(float speed) {
        if (image == null)
            image = GetComponent<Image>();
        StartCoroutine(FadeOut(speed));
    }
    private IEnumerator FadeIn(float speed) {
        for(opacity = 1; opacity > 0f; opacity -= Time.deltaTime / speed) {
            image.color = new Color(0, 0, 0, opacity);
            yield return null;
        }
    }

    private IEnumerator FadeOut(float speed) {
        for (opacity = 0; opacity < 1f; opacity += Time.deltaTime / speed) {
            image.color = new Color(0, 0, 0, opacity);
            yield return null;
        }
    }
}
