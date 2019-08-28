using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class MazeVRNetworkBehaviour : NetworkBehaviour
    {
        // starting entities etc.
        [SerializeField]
        private Network network;

        [SerializeField]
        private List<NetworkBehaviour> toRegister;

        private void Awake()
        {
            network = this.GetComponent<Network>();
            toRegister.Insert(0, this);
        }

        private void Start()
        {
            RegisterAll();
        }

        private void RegisterAll()
        {
            for (int i = 0; i < toRegister.Count; i++)
            {
                Register(i);
            }
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
            int registeredId = message.GetInt(1);
            int tableId = message.GetInt(2);

            network.TryRegister(toRegister[tableId], registeredId);
        }
    }
}
