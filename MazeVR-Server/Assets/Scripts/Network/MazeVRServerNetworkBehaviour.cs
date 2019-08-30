using MazeVR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeVR.Server
{
    public class MazeVRServerNetworkBehaviour : MazeVRNetworkBehaviour
    {
        protected void OnEnable()
        {
            network.Ready += Network_Ready;
        }

        protected void OnDisable()
        {
            network.Ready -= Network_Ready;
        }

        private void Network_Ready()
        {
            this.RegisterAll();
        }

        public override void Synchronize(OscMessage message)
        {
            //base.Synchronize(message);
        }
    }
}
