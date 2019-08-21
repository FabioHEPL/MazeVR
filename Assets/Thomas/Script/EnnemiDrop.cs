using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiDrop : MonoBehaviour
{
    public LayerMask ennemiSpawn;
    public LayerMask ennemiLayer;
    public GameObject ennemiPrefab;
    public GameObject enemi;
    private bool mouseHold = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !mouseHold)
        {
            enemi = Instantiate(ennemiPrefab, GetWorldPointFromMouse(), Quaternion.identity);
            mouseHold = true;
        }

        if (mouseHold)
        {
            enemi.transform.position = GetWorldPointFromMouse();
        }

        if (Input.GetMouseButtonUp(1))
        {
            mouseHold = false;
        }
    }

    private Vector3 GetWorldPointFromMouse()
    {
        RaycastHit rayHit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, ennemiSpawn))
        {
            Debug.Log(rayHit);
            return rayHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
