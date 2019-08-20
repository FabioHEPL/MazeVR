using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiDrop : MonoBehaviour
{
    public LayerMask ennemiSpawn;

    public GameObject ennemi;

    public GameObject ennemiPositionOnMouse;

    [Header("Debug")]
    public Vector3 positionMouse;
    public float amplificator = 3;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit rayHit;

            if (ennemiPositionOnMouse == null)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, ennemiSpawn))
                {
                    ennemiPositionOnMouse = Instantiate(ennemi, transform.position = rayHit.collider.transform.position, Quaternion.identity);
                }
            }
            positionMouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            MousePosition(positionMouse);
        }

        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit rayHit;

            if (ennemiPositionOnMouse == null)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, ennemiSpawn))
                {
                    ennemiPositionOnMouse.transform.position = rayHit.collider.transform.position;
                }
            }
            ennemiPositionOnMouse = null;
        }
    }

    private void MousePosition(Vector3 positionMouse)
    {
        Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (positionMouse != mousePosition)
        {
            Debug.Log("bouge");
            ennemiPositionOnMouse.transform.position = ennemiPositionOnMouse.transform.position.normalized + (new Vector3(mousePosition.x, 0, mousePosition.y));
        }
    }
}
