using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class MobFactoryNetworkBehaviour : NetworkBehaviour
    {
        public override NetworkEntity Entity => throw new NotImplementedException();

        private NetworkFactory networkFactory;

        [SerializeField]
        public MobFactoryBehaviour mobFactory;

        public override void OnNetworkUpdate(NetworkUpdate update)
        {
            throw new NotImplementedException();
        }

        private void OnEnable()
        {
            mobFactory.Created += MobFactory_Created;
        }

        private void MobFactory_Created(object sender, MobCreatedArgs args)
        {
            Mob mob = new Mob(args.Mob);
            networkFactory.Network.Register(mob);

            networkFactory.Update(new NetworkUpdate("Created"));
        }

        private void OnDisable()
        {
            
        }
    }
}
