using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public abstract class Network : MonoBehaviour
    {
        public abstract int Register(NetworkBehaviour behaviour);
        public abstract bool TryRegister(NetworkBehaviour behaviour, int id);
        public abstract NetworkBehaviour GetBehaviour(int id);

        public event Action Ready;
        
        protected virtual void OnReady()
        {
            this.Ready?.Invoke();
        }

    }
}
