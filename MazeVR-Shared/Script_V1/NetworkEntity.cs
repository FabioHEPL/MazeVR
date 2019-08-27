using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR
{
    public abstract class NetworkEntity : MonoBehaviour
    { 
        public abstract int ID { get; }

        public abstract void Synchronize(OscMessage message);

        public event EventHandler<NetworkEntityUpdatedArgs> Updated;

        protected virtual void OnUpdated(NetworkEntityUpdatedArgs args)
        {
            Updated?.Invoke(this, args);
        }
    }
}


