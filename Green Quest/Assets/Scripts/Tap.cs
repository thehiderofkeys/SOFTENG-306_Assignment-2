using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Class to enable callback of Animator Function through Unity Events
 */
public class Tap : MonoBehaviour
{
    public void SetOn(bool isOn) //TO DO: Generalise the class functioanlity to enable other Animator method callback on other objects.
    {
        GetComponent<Animator>().SetBool("isOn", isOn);
    }
}
