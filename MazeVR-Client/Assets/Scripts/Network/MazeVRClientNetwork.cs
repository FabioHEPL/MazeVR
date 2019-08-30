using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR.Client
{
    public class MazeVRClientNetwork : MazeVRNetwork
    {
        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void Start()
        {
            NetworkDebug.Log($"Waiting for server call...");
            osc.SetAddressHandler("/ServerCall", ServerCall);
        }

        protected void ServerCall(OscMessage message)
        {
            string serverIP = String.Format("{0}.{1}.{2}.{3}",
                message.GetInt(0), message.GetInt(1), message.GetInt(2), message.GetInt(3));

            osc.OutIP = serverIP;

            NetworkDebug.Log($"Server IP address should be {serverIP}, checking back...");

            SendServerCheck();
            AwaitServerConfirmation();
        }

        private void AwaitServerConfirmation()
        {
            osc.SetAddressHandler("/ServerConfirmation", ServerConfirmation);
        }

        protected void SendServerCheck()
        {
            OscMessage message = new OscMessage();
            message.address = "/ServerCheck";
            this.osc.Send(message);
        }

        protected void ServerConfirmation(OscMessage message)
        {
            NetworkDebug.Log($"Connected to server.");
            this.OnReady();            
            SendClientConfirmation();       
        }

        protected void SendClientConfirmation()
        {
            OscMessage message = new OscMessage();
            message.address = "/ClientConfirmation";
            this.osc.Send(message);
        }

        protected override void OnReady()
        {
            this.osc.Reset();
            base.Start();
            base.OnReady();
        }
    }
}
