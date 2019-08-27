using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSpawn : MonoBehaviour
{
    [SerializeField] GameObject ennemiPrefab;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask spwanerLayer;
    [SerializeField] LayerMask toAvoidLayer;

    [SerializeField] bool drag = false;

    public Collider[] youShouldNotPass;
    GameObject ennemiToDragAndDroping;
    public Vector3 startDroppingPosition;

    void Update()
    {
        // inputs
        if (Input.GetMouseButtonDown(1))
        {       
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, spwanerLayer))
            {

            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, spwanerLayer))
            {

            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, enemyLayer))
            {
                drag = true;
                if(ennemiPrefab)
                ennemiToDragAndDroping = Instantiate(ennemiPrefab, rayHit.point, Quaternion.identity);

                startDroppingPosition = rayHit.point;
            }
            
        }

        if (Input.GetMouseButtonUp(1))
        {
            drag = false;
        }

        // drag
        if (drag == true && ennemiToDragAndDroping)
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, enemyLayer))
            {
                youShouldNotPass = Physics.OverlapSphere(rayHit.point, 1f, toAvoidLayer);

                if (youShouldNotPass.Length > 0)
                {
                    drag = false;
                }
                else
                {
                    ennemiToDragAndDroping.transform.position = rayHit.point;
                }

                if (Input.GetMouseButton(1))
                {
                    bool isTouchingWall = youShouldNotPass.Length > 0;
                    if (isTouchingWall)
                    {
                        ennemiToDragAndDroping.transform.position = startDroppingPosition;
                        drag = true;
                        return;
                    }
                    else
                    {
                    ennemiToDragAndDroping.transform.position = rayHit.point;
                    drag = true;
                    return;
                    }
                }
            }
        }
    }
}
