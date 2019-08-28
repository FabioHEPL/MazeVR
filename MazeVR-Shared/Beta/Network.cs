using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    [System.Serializable]
    public abstract class Network : MonoBehaviour
    {
        public abstract void Register(NetworkEntity entity);

        //public event EventHandler<NetworkEntityUpdatedArgs> Updated;

        //protected virtual void OnUpdated(NetworkEntityUpdatedArgs args)
        //{
        //    Updated?.Invoke(this, args);
        //}
    }
}
