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
        protected Network network;

        [SerializeField]
        protected List<NetworkBehaviour> toRegister;

        protected virtual void Awake()
        {
            network = this.GetComponent<Network>();
            //toRegister.Insert(0, this);
        }

        protected virtual void Start()
        {
            this.RegisterSelf();
            //this.RegisterAll();
        }

        protected void RegisterSelf()
        {
            network.TryRegister(this, 0);
        }

        protected void RegisterAll()
        {
            //RegisterSelf();

            for (int i = 0; i < toRegister.Count; i++)
            {                
                Register(i);
            }
        }

        protected void Register(int tableId)
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
