using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR
{
    public class NetworkEntityUpdatedArgs
    {
        private object[] values;
        private string label;

        public string Label => label;
        public object[] Values => values;

        public NetworkEntityUpdatedArgs(string label, params object[] values)
        {
            this.label = label;
            this.values = values;
        }
    }
}
