using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MazeVR
{
    public class Network : MonoBehaviour
    {
        [SerializeField]
        private List<LocalEntity> localEntities;

        [SerializeField]
        private List<RemoteEntity> remoteEntities;

        //[SerializeField]
        private OSC osc;     

        public virtual void Register_Remote(RemoteEntity entity)
        {
            this.remoteEntities.Add(entity);            
        }

        public virtual void Register_Local(LocalEntity entity)
        {
            localEntities.Add(entity);
            entity.Updated += Entity_Updated;
        }

        private void Entity_Updated(object sender, LocalEntityUpdatedArgs args)
        {
            LocalEntity entity = (LocalEntity)sender;
            OscMessage message = BuildMessage(entity.ID, args);
            this.osc.Send(message);
        }

        private static OscMessage BuildMessage(int entityId, LocalEntityUpdatedArgs args)
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
            RemoteEntity entity = remoteEntities.FirstOrDefault(e => e.ID == entityId);

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
            this.localEntities = GameObject.FindObjectsOfType<LocalEntity>().ToList();
            this.remoteEntities = GameObject.FindObjectsOfType<RemoteEntity>().ToList();
            this.osc = this.GetComponent<OSC>();
        }

        private void Start()
        {
            osc.SetAllMessageHandler(Synchronise_Entity);
        }

        private void OnEnable()
        {
            foreach (LocalEntity entity in this.localEntities)
            {
                entity.Updated += Entity_Updated;
            }
        }

        private void OnDisable()
        {
            foreach (LocalEntity entity in this.localEntities)
            {
                entity.Updated -= Entity_Updated;
            }
        }
    }

}
