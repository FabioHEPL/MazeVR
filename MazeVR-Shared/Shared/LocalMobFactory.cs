using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR.Shared
{
    public class LocalMobFactory : NetworkBehaviour
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
            NetworkBehaviour behaviour = args.Mob.GetComponent<NetworkBehaviour>();
            int registeredId = network.Register(behaviour);

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

        }
    }
}
