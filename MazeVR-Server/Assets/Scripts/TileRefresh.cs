using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRefresh : MonoBehaviour
{
    public Collider[] tiles;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bounds bounds = tiles[0].bounds;
            AstarPath.active.UpdateGraphs(bounds);
            Debug.Log("Refresh 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bounds bounds = tiles[1].bounds;
            AstarPath.active.UpdateGraphs(bounds);
            Debug.Log("Refresh 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Bounds bounds = tiles[2].bounds;
            AstarPath.active.UpdateGraphs(bounds);
            Debug.Log("Refresh 3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Bounds bounds = tiles[3].bounds;
            AstarPath.active.UpdateGraphs(bounds);
            Debug.Log("Refresh 4");
        }
    }
}
