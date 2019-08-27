using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR
{
    public abstract class NetworkEntity : MonoBehaviour
    {
        public event EventHandler<NetworkEntityUpdatedArgs> Updated;

        public abstract int ID { get; }

        public abstract void Synchronize(OscMessage message);

        protected virtual void OnUpdated(NetworkEntityUpdatedArgs args)
        {
            Updated?.Invoke(this, args);
        }
    }
}


