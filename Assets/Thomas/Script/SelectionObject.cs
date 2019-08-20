using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionObject : MonoBehaviour
{
    [SerializeField] private LayerMask selectableObject;

    float _rotate = 90;
    bool boutonRotateRightActiv = false;
    bool boutonRotateLeftActiv = false;

    public GameObject objectSelected1;
    public GameObject objectSelected2;

    public Material hightlight;
    public Material baseMaterial;

    public KeyCode rotateR;
    public KeyCode rotateL;
    public KeyCode swap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, selectableObject))
            {
                if (objectSelected1 == null)
                {
                    objectSelected1 = rayHit.collider.gameObject;
                    objectSelected1.GetComponent<Renderer>().material = hightlight;
                }
                else if (objectSelected1 != null)
                {
                    objectSelected2 = rayHit.collider.gameObject;
                    objectSelected2.GetComponent<Renderer>().material = hightlight;

                    if (objectSelected2 == objectSelected1)
                    {
                        objectSelected2 = null;
                    }
                }
            }
        }

        if (Input.GetKeyDown(rotateR) && objectSelected1 != null)
        {
            boutonRotateRightActiv = true;
            RotateWall(objectSelected1, boutonRotateRightActiv, boutonRotateLeftActiv);
            objectSelected1 = null;
        }

        if (Input.GetKeyDown(rotateL) && objectSelected1 != null)
        {
            boutonRotateLeftActiv = true;
            RotateWall(objectSelected1, boutonRotateRightActiv, boutonRotateLeftActiv);
            objectSelected1 = null;
        }

        if (Input.GetKeyDown(swap) && objectSelected1 != null && objectSelected2 != null)
        {
            SwitchObject(objectSelected1, objectSelected2);
            objectSelected1 = null;
            objectSelected2 = null;
        }
    }

    private void SwitchObject(GameObject s1, GameObject s2)
    {
        Vector3 switcherObject = s1.transform.position;

        s1.transform.position = s2.transform.position;
        s2.transform.position = switcherObject;

        s1.GetComponent<Renderer>().material = baseMaterial;
        s2.GetComponent<Renderer>().material = baseMaterial;
    }

    void RotateWall(GameObject o, bool bRA, bool bLA)
    {
        if (bRA == true)
        {
            o.transform.Rotate(0.0f, _rotate, 0.0f);
            o.GetComponent<Renderer>().material = baseMaterial;
            bRA = false;
        }
        else if (bLA == true)
        {
            o.transform.Rotate(0.0f, -_rotate, 0.0f);
            o.GetComponent<Renderer>().material = baseMaterial;
            bLA = false;
        }

        if (objectSelected2 != null)
        {
            objectSelected2.GetComponent<Renderer>().material = baseMaterial;
            objectSelected2 = null;
        }
    }
}
