using MazeVR.Shared;

namespace MazeVR.Beta
{
    public class NetworkUpdate
    {
        private object[] values;
        private string label;

        public string Label => label;
        public object[] Values => values;

        public OscMessage Message { get; set; }

        public NetworkUpdate(string label, params object[] values)
        {
            this.label = label;
            this.values = values;
        }
    }
}