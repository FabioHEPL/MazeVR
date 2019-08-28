using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class Mob : NetworkEntity
    {
        public Mob(GameObject gameObject)
            : base(gameObject)
        { }

        public override int ID => throw new NotImplementedException();

        public override void Synchronize(NetworkUpdate update)
        {            
            GameObject.GetComponent<NetworkBehaviour>().OnNetworkUpdate(update);
        }

        public override void Update(NetworkUpdate update)
        {
            OnUpdated(new NetworkEntityUpdatedArgs(update));
        }
    }
}
