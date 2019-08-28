using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class MazeVRServer : NetworkBehaviour
    {
        // starting entities etc.
        [SerializeField]
        private Network network;

        [SerializeField]
        private List<NetworkBehaviour> toRegister;

        private void Awake()
        {
            network = this.GetComponent<Network>();
       
        }

        private void Start()
        {
            RegisterSelf();
            RegisterAll();
        }

        private void RegisterAll()
        {
            for (int i = 0; i < toRegister.Count; i++)
            {
                Register(i);
            }
        }

        private void RegisterSelf()
        {
            network.TryRegister(this, 0);
        }

        private void Register(int tableId)
        {
            int registeredId = network.Register(toRegister[tableId]);

            NetworkBehaviourUpdatedArgs args =
                new NetworkBehaviourUpdatedArgs("Registered", registeredId, tableId);

            this.OnUpdated(args);
        }

        public override void Synchronize(OscMessage message)
        {
            
        }
    }
}
