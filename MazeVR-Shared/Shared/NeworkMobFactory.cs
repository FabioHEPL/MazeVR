using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR.Shared
{
    public class NetworkMobFactory : NetworkBehaviour
    {
        [SerializeField]
        private MobFactory mobFactory;

        [SerializeField]
        private Network network;       

        private void Awake()
        {
            network = GameObject.FindObjectOfType<Network>();
        }

        private void OnEnable()
        {
            mobFactory.Created += MobFactory_Created;
        }

        private void OnDisable()
        {
            mobFactory.Created -= MobFactory_Created;
        }

        private void MobFactory_Created(object sender, MobCreatedArgs args)
        {
            NetworkBehaviour entity = args.Mob.GetComponent<NetworkBehaviour>();
            int registeredId = network.Register(entity);

            float x = args.Mob.transform.position.x;
            float y = args.Mob.transform.position.y;
            float z = args.Mob.transform.position.z;

            NetworkBehaviourUpdatedArgs entityArgs = new NetworkBehaviourUpdatedArgs("Created", registeredId, x, y, z);
            OnUpdated(entityArgs);
        }

        protected override void OnUpdated(NetworkBehaviourUpdatedArgs args)
        {
            base.OnUpdated(args);
        }

        public override void Synchronize(OscMessage message)
        {
            // NetworkComponent = select Component ("message.address")

            // networkComponent.Update(message);

            if (message.address.Equals("/Created"))
            {

                Vector3 mobPosition = Vector3.zero;

                mobPosition.x = message.GetFloat(1);
                mobPosition.y = message.GetFloat(2);
                mobPosition.z = message.GetFloat(3);

                GameObject mob = null;

                NetworkBehaviour entity = mob.GetComponent<NetworkBehaviour>();


               // network.Register_Remote(entity);
            }
        }
    }
}
