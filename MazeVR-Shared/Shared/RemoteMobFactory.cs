using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR.Shared
{
    public class RemoteMobFactory : NetworkBehaviour
    {
        [SerializeField]
        private MobFactory mobFactory;

        [SerializeField]
        private Network network;

        private void Awake()
        {
            network = GameObject.FindObjectOfType<Network>();
        }

        public override void Synchronize(OscMessage message)
        {
            Vector3 mobPosition = Vector3.zero;

            mobPosition.x = message.GetFloat(2);
            mobPosition.y = message.GetFloat(3);
            mobPosition.z = message.GetFloat(4);
            
            GameObject mob = mobFactory.CreateMob(mobPosition);
            NetworkBehaviour behaviour = mob.GetComponent<NetworkBehaviour>();

            int registeredId = message.GetInt(1);
            network.TryRegister(behaviour, registeredId);
        }
    }
}
