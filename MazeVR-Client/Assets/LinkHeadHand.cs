using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkHeadHand : MonoBehaviour
       
{
    public GameObject head;
    public GameObject handRight;
    public GameObject handLeft;


    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(head.transform.position, handRight.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            handRight.SetActive(false);
        }
        else
        {
            handRight.SetActive(true);
        }

        if (Physics.Raycast(head.transform.position, handLeft.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            handLeft.SetActive(false);
        }
        else
        {
            handLeft.SetActive(true);
        }
    }
}
