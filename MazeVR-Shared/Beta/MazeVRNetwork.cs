using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{    
    public class MazeVRNetwork : Network
    {
        [SerializeField]
        private int countDebug = 0;

        [SerializeField]
        private List<NetworkEntity> entities;

        [SerializeField]
        private NetworkEntity f;

        [SerializeField]
        private OSC osc;  

        public override void Register(NetworkEntity entity)
        {

            entities.Add(entity);          

            entity.Updated += Entity_Updated;
            countDebug++;

            Debug.Log($"Entity '{entity.GameObject.name}' registered on network with id '{GetEntityIndex(entity)}'.");
        }

        private void Entity_Updated(object sender, NetworkEntityUpdatedArgs args)
        {
            NetworkEntity entity = (NetworkEntity)sender;
            OscMessage message = BuildMessage(GetEntityIndex(entity), args);
            this.osc.Send(message);
        }

        private int GetEntityIndex(NetworkEntity entity)
        {
            return entities.IndexOf(entity);
        }

        private static OscMessage BuildMessage(int entityId, NetworkEntityUpdatedArgs args)
        {
            OscMessage message = new OscMessage();
            message.address = String.Format($"/{args.Update.Label}");
            message.values.Add(entityId);

            foreach (object value in args.Update.Values)
                message.values.Add(value);

            return message;
        }

        private void Synchronise_Entity(OscMessage message)
        {
            int entityId = message.GetInt(0);
            NetworkEntity entity = entities.ElementAtOrDefault(entityId);

            if (entity == null)
            {
                Debug.LogWarning($"Could not find entity with ID number {entityId}");
            }
            else
            {
                entity.Synchronize(new NetworkUpdate("", null) { Message = message });
            }
        }

        private void Awake()
        {           
            this.osc = this.GetComponent<OSC>();
            this.entities = new List<NetworkEntity>();
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

