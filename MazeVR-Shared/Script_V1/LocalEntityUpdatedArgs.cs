using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeVR
{
    public class LocalEntityUpdatedArgs : EventArgs
    {
        private object[] values;
        private string label;

        public string Label => label;
        public object[] Values => values;

        public LocalEntityUpdatedArgs(string label, params object[] values)
        {
            this.label = label;
            this.values = values;
        }
    }
}