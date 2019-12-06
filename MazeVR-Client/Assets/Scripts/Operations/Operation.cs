using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public abstract class Operation : ScriptableObject
    {
        public abstract void Execute();
        public event Action Executed;

        protected virtual void OnExecuted()
        {
            Executed?.Invoke();
        }

    }
}