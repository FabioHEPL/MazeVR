using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class MazeVRClient : NetworkBehaviour
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
        }


        private void RegisterSelf()
        {
            network.TryRegister(this, 0);
        }

        public override void Synchronize(OscMessage message)
        {


            int registeredId = message.GetInt(1);
            int tableId = message.GetInt(2);

       

            network.TryRegister(toRegister[tableId], registeredId);
        }
    }
}
