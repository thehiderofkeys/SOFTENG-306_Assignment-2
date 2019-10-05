using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public void SetOn(bool isOn)
    {
        GetComponent<Animator>().SetBool("isOn", isOn);
    }
}
