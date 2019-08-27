using System;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public abstract class NetworkOperation
    {
        public abstract void Execute();
        public event EventHandler<NetworkOperationExecutedArgs> Executed;

        protected virtual void OnExecuted(NetworkOperationExecutedArgs args)
        {
            Executed?.Invoke(this, args);
        }

        public abstract int ID { get; }
    }
}