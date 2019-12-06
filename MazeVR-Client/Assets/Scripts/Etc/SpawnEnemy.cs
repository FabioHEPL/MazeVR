﻿using MazeVR;
using MazeVR.Shared;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] MobFactory mobFactory;
        [SerializeField] GameObject button;

        [SerializeField] LayerMask spawnAreaLayerMask;
        [SerializeField] string toAvoidLayerName;

        [SerializeField] bool dragging = false;

        public Collider[] youShouldNotPass;
        GameObject enemy;
        public Vector3 startDroppingPosition;

        void Update()
        {
            // inputs
            if (Input.GetMouseButtonDown(1) && !dragging)
            {
                //mobSpawner2 = mobSpawner2.GetComponent<>();

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask(LayerMask.LayerToName(button.layer))))
                {
                    if (hit.collider.gameObject.Equals(button))
                    {
                        enemy = mobFactory.CreateMob(hit.point);

                        dragging = true;
                    }
                }
            }

            if (Input.GetMouseButtonUp(1) && dragging)
            {
                enemy.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
                dragging = false;
            }

            // drag
            if (dragging == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, spawnAreaLayerMask))
                {
                    if (hit.collider.gameObject.layer != LayerMask.NameToLayer(toAvoidLayerName))
                    {
                        enemy.transform.position = hit.point;
                    }
                }
            }
        }
    }
}