using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveHand : MonoBehaviour
{
    public LayerMask layer;
    public GameObject handcollider;
    public GameObject hand;


    private void OnTriggerEnter(Collider layer)
    {
        if (handcollider)
        {
            hand.SetActive(false);
            Debug.Log("Bye Bye !");
        }
    }

    private void OnTriggerExit(Collider layer)
    {
        if (handcollider)
        {
            hand.SetActive(true);
            Debug.Log("Hi Again!");
        }
    }
}