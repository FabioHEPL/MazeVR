using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public abstract class Operation : ScriptableObject
    {
        public abstract void Execute();
    }
}