using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public abstract class NetworkBehaviour : MonoBehaviour
    {
        public abstract NetworkEntity Entity { get; }
        public abstract void OnNetworkUpdate(NetworkUpdate update);  
    }
}
