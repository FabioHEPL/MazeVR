using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class NetworkMobFactory : NetworkEntity
    {
        [SerializeField]
        private int id = 4;

        [SerializeField]
        private MobFactory mobFactory;

        [SerializeField]
        private Network network;

        public override int ID => this.id;

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
            NetworkEntity entity = args.Mob.GetComponent<NetworkEntity>();
            network.Register(entity);

            float x = args.Mob.transform.position.x;
            float y = args.Mob.transform.position.y;
            float z = args.Mob.transform.position.z;

            NetworkEntityUpdatedArgs entityArgs = new NetworkEntityUpdatedArgs("Created", x, y, z);
            OnUpdated(entityArgs);
        }

        protected override void OnUpdated(NetworkEntityUpdatedArgs args)
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

                GameObject mob = CreateMob(mobPosition);

                NetworkEntity entity = mob.GetComponent<NetworkEntity>();


                network.Register_Remote(entity);
            }
        }
    }
}
