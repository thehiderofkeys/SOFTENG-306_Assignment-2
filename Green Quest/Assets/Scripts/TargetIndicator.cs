using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public string TagName;
    public Transform Arrow;
    private Renderer[] visuals;
    private bool visible;
    private void Start()
    {
        visuals = GetComponentsInChildren<Renderer>();
        foreach (Renderer visual in visuals)
        {
            visual.enabled = false;
        }
    }

    // If the object is not within the camera frame, produce an arrow that shows where the seedling is. 
    void LateUpdate()
    {
        GameObject target = GameObject.FindGameObjectWithTag(TagName);
        bool enabled = target && !target.GetComponentInChildren<Renderer>().isVisible;
        SetVisible(enabled);
        if (enabled)
        {
            Vector3 camTopRight = Camera.main.ViewportToWorldPoint(Vector2.one) - (Vector3) Vector2.one;
            Vector3 camBottomLeft = Camera.main.ViewportToWorldPoint(Vector2.zero) + (Vector3)Vector2.one;
            Vector3 indicatorPos = target.transform.position;
            indicatorPos.x = Mathf.Clamp(indicatorPos.x, camBottomLeft.x, camTopRight.x);
            indicatorPos.y = Mathf.Clamp(indicatorPos.y, camBottomLeft.y, camTopRight.y);
            transform.position = indicatorPos;
            Arrow.LookAt(target.transform, Vector3.back);
        }
    }
    void SetVisible(bool isVisible)
    {
        if (visible == isVisible)
            return;
        foreach (Renderer visual in visuals)
        {
            visual.enabled = isVisible;
        }
        visible = isVisible;
    }
}
