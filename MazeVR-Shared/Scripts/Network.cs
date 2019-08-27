﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MazeVR
{
    public class Network : MonoBehaviour
    {
        [SerializeField]
        private List<NetworkEntity> entities;       

        private OSC osc;     

        public virtual void Register(NetworkEntity entity)
        {
            entities.Add(entity);
            entity.Updated += Entity_Updated;
        }

        private void Entity_Updated(object sender, NetworkEntityUpdatedArgs args)
        {
            NetworkEntity entity = (NetworkEntity)sender;
            OscMessage message = BuildMessage(entity.ID, args);
            this.osc.Send(message);
        }

        private static OscMessage BuildMessage(int entityId, NetworkEntityUpdatedArgs args)
        {
            OscMessage message = new OscMessage();
            message.address = String.Format($"/{args.Label}");
            message.values.Add(entityId);

            foreach (object value in args.Values)
                message.values.Add(value);

            return message;
        }

        private void Synchronise_Entity(OscMessage message)
        {
            int entityId = message.GetInt(0);
            NetworkEntity entity = entities.FirstOrDefault(e => e.ID == entityId);

            if (entity == null)
            {
                Debug.LogWarning($"Could not find entity with ID number {entityId}");                    
            }
            else
            {
                entity.Synchronize(message);
            }
        }

        private void Awake()
        {            
            this.entities = GameObject.FindObjectsOfType<NetworkEntity>().ToList();
            this.osc = this.GetComponent<OSC>();
        }

        private void Start()
        {
            osc.SetAllMessageHandler(Synchronise_Entity);
        }

        private void OnEnable()
        {
            foreach (NetworkEntity entity in this.entities)
            {
                entity.Updated += Entity_Updated;
            }
        }

        private void OnDisable()
        {
            foreach (NetworkEntity entity in this.entities)
            {
                entity.Updated -= Entity_Updated;
            }
        }
    }

}
