using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    [System.Serializable]
    public abstract class NetworkEntity : System.Object
    {
        public NetworkEntity(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public abstract int ID { get; }

        public virtual GameObject GameObject { get => this.gameObject; }

        private GameObject gameObject;

        public abstract void Synchronize(NetworkUpdate update);

        public abstract void Update(NetworkUpdate update);

        public event EventHandler<NetworkEntityUpdatedArgs> Updated;

        protected virtual void OnUpdated(NetworkEntityUpdatedArgs args)
        {
            Updated?.Invoke(this, args);
        }
    }

    public class NetworkEntityUpdatedArgs : EventArgs
    {
        private NetworkUpdate update;
        public NetworkUpdate Update => update;        

        public NetworkEntityUpdatedArgs(NetworkUpdate update)
        {
            this.update = update;
        }
    }
}
