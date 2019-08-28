using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MazeVR.Server
{
    [CreateAssetMenu(fileName = "Spawn Mob", menuName = "Operations/Spawn Mob")]
    public class SpawnMob : Operation
    {
        [SerializeField]
        private GameObject mobPrefab;
        [SerializeField]
        LayerMask spawnAreaLayerMask;
        [SerializeField]
        string toAvoidLayerName;

        private GameObject mob;

        [SerializeField]
        private bool dragging = false;

        public override void Execute()
        {
            //if (!dragging)
            //{
            //   // Vector3 point = GetRaycastPoint();
            //    if (point != Vector3.zero)
            //    {
            //        mob = Instantiate(mobPrefab, point, Quaternion.identity);
            //    }

            //    dragging = true;
            //}
            //else
            //{
            //    //Vector3 point = GetRaycastPoint();
            //    if (point != Vector3.zero)
            //    {
            //        //mob.
            //    }
            //}
        }

        //        RaycastHit hit;

        //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask(LayerMask.LayerToName(button.layer))))
        //        {
        //            if (hit.collider.gameObject.Equals(button))
        //            {
        //                enemy = Instantiate(enemyPrefab, hit.point, Quaternion.identity);
        //                dragging = true;
        //            }
        //        }
        //    }

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layer))
        //    {
        //        selection.Include(hit.collider.gameObject);
        //    }

        //    hit = GetRaycastPoint();
        //}

        //private Vector3 GetRaycastPoint()
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, spawnAreaLayerMask))
        //    {
        //        Debug.Log(LayerMask.LayerToName(hit.collider.gameObject.layer));
        //        if (hit.collider.gameObject.layer != LayerMask.NameToLayer(toAvoidLayerName))
        //        {
        //            enemy.transform.position = hit.point;
        //        }
        //    }

        //    return hit;
        //}
    }
}