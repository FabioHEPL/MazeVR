using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class LocalMobFactory : LocalEntity
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
            LocalEntity entity = args.Mob.GetComponent<LocalEntity>();
            network.Register_Local(entity);

            float x = args.Mob.transform.position.x;
            float y = args.Mob.transform.position.y;
            float z = args.Mob.transform.position.z;

            LocalEntityUpdatedArgs entityArgs = new LocalEntityUpdatedArgs("Created", x, y, z);
            OnUpdated(entityArgs);
        }

        protected override void OnUpdated(LocalEntityUpdatedArgs args)
        {
            base.OnUpdated(args);
        }
    }
}
