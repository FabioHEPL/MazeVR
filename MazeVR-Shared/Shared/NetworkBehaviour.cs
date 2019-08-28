using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Shared
{
    public abstract class NetworkBehaviour : MonoBehaviour
    { 
        public abstract void Synchronize(OscMessage message);

        public event EventHandler<NetworkBehaviourUpdatedArgs> Updated;

        protected virtual void OnUpdated(NetworkBehaviourUpdatedArgs args)
        {
            Updated?.Invoke(this, args);            
        }
    }
}


