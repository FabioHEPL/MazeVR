using System;
using UnityEngine;

namespace MazeVR
{
    public abstract class Operation : ScriptableObject
    {
        public abstract void Execute();
        public event EventHandler<OperationExecutedArgs> Executed;

        protected virtual void OnExecuted(OperationExecutedArgs args)
        {
            Executed?.Invoke(this, args);
        }
    }
}