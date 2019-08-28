using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class Player : NetworkEntity
    {
        public Player(GameObject gameObject)
            : base(gameObject)
        {
            behaviour = gameObject.GetComponent<NetworkBehaviour>();
            Debug.Log($"Player behaviour : {behaviour}");            
        }

        private NetworkBehaviour behaviour;

        public override int ID => throw new NotImplementedException();

        public override void Synchronize(NetworkUpdate update)
        {
            behaviour.OnNetworkUpdate(update);
        }

        public override void Update(NetworkUpdate update)
        {
            OnUpdated(new NetworkEntityUpdatedArgs(update));
        }
    }
}
