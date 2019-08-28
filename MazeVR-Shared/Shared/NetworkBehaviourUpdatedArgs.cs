using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Shared
{
    public class NetworkBehaviourUpdatedArgs : EventArgs
    {
        private object[] values;
        private string label;

        public string Label => label;
        public object[] Values => values;

        public NetworkBehaviourUpdatedArgs(string label, params object[] values)
        {
            this.label = label;
            this.values = values;
        }
    }
}
