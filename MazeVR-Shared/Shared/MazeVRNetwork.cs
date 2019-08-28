using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MazeVR.Shared
{
    public class MazeVRNetwork : Network
    {
        [SerializeField]
        private List<RegisteredNetworkBehaviour> registeredBehaviours;       

        private OSC osc;

        public override int Register(NetworkBehaviour behaviour)
        {
            // TODO: find first available id
            // TEMP:
            RegisteredNetworkBehaviour registered = RegisterBehaviour(behaviour, this.registeredBehaviours.Count);

            return registered.ID;
        }

        private RegisteredNetworkBehaviour RegisterBehaviour(NetworkBehaviour behaviour, int id)
        {
            RegisteredNetworkBehaviour registered = new RegisteredNetworkBehaviour(behaviour, this.registeredBehaviours.Count);
            AddToCollection(registered);

            Debug.Log($"Registered entity '{registered.Behaviour.gameObject.name}' with ID : '{registered.ID}'");

            return registered;
        }

        public override bool TryRegister(NetworkBehaviour behaviour, int id)
        {
            RegisteredNetworkBehaviour registered =
                this.registeredBehaviours.FirstOrDefault(r => r.ID == id);

            if (registered == null)
            {
                RegisterBehaviour(behaviour, this.registeredBehaviours.Count);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override NetworkBehaviour GetBehaviour(int id)
        {
            RegisteredNetworkBehaviour registered = registeredBehaviours.FirstOrDefault(r => r.ID == id);

            if (registered == null)
            {
                Debug.Log($"Could not find registered behaviour with ID : '{id}'");
            }
            else
            {
                Debug.Log($"Found registered behaviour with ID : '{id}'");
            }

            return registered.Behaviour;
        }

        private void AddToCollection(RegisteredNetworkBehaviour registered)
        {
            this.registeredBehaviours.Add(registered);
            registered.Behaviour.Updated += Behaviour_Updated;
        }

        private void Behaviour_Updated(object sender, NetworkBehaviourUpdatedArgs args)
        {
            NetworkBehaviour behaviour = (NetworkBehaviour)sender;
            OscMessage message = BuildMessage(GetBehaviourId(behaviour), args);
            this.osc.Send(message);
        }

        private static OscMessage BuildMessage(int behaviourId, NetworkBehaviourUpdatedArgs args)
        {
            OscMessage message = new OscMessage();
            message.address = String.Format($"/{args.Label}");
            message.values.Add(behaviourId);

            foreach (object value in args.Values)
                message.values.Add(value);

            return message;
        }

        private void Synchronise_Behaviour(OscMessage message)
        {
            int behaviourId = message.GetInt(0);
            NetworkBehaviour behaviour = GetBehaviour(behaviourId);

            if (behaviour == null)
            {
                Debug.LogWarning($"Could not find behaviour with ID number {behaviourId}");                    
            }
            else
            {
                message.address = message.address.Substring(1); // removes '/' at start
                behaviour.Synchronize(message);
            }
        }

        private void Awake()
        {            
            this.registeredBehaviours = new List<RegisteredNetworkBehaviour>();
            this.osc = this.GetComponent<OSC>();
        }

        private void Start()
        {
            osc.SetAllMessageHandler(Synchronise_Behaviour);
        }

        private void OnEnable()
        {
            foreach (RegisteredNetworkBehaviour registered in this.registeredBehaviours)
            {
                registered.Behaviour.Updated += Behaviour_Updated;
            }
        }

        private void OnDisable()
        {
            foreach (RegisteredNetworkBehaviour registered in this.registeredBehaviours)
            {
                registered.Behaviour.Updated -= Behaviour_Updated;
            }
        } 
        
        private int GetBehaviourId(Behaviour behaviour)
        {
            // TODO: UpdateEvent on registered networkbehaviour

            return this.registeredBehaviours.First(r => r.Behaviour.Equals(behaviour)).ID;            
        }
    }
}
