using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR.Server
{
    public class MazeVRServerNetwork : MazeVRNetwork
    {
        [SerializeField]
        private bool debugMode = true;

        protected override void Start()
        {
            if (debugMode)
            {
                SendClientIP(this.osc.OutIP);
                AwaitServerCheck();
            }
        }

        public void UI_ClientIPEntered(string clientIP)
        {
            this.osc.OutIP = clientIP;
            SendClientIP(clientIP);
            AwaitServerCheck();
        }

        private void AwaitServerCheck()
        {
            osc.SetAddressHandler("/ServerCheck", ServerCheck);
        }

        protected void SendClientIP(string clientIP)
        {
            OscMessage message = new OscMessage();

            string[] ipElements = Utils.GetLocalIPAddress().Split('.');

            message.address = "/ServerCall";

            message.values.Add(Int32.Parse(ipElements[0]));
            message.values.Add(Int32.Parse(ipElements[1]));
            message.values.Add(Int32.Parse(ipElements[2]));
            message.values.Add(Int32.Parse(ipElements[3]));

            NetworkDebug.Log($"Sending this server IP address ('{Utils.GetLocalIPAddress()}') to the client ('{clientIP}')");

            this.osc.Send(message);
        }

        protected void ServerCheck(OscMessage message)
        {
            // TODO:
            // implement timeout
            NetworkDebug.Log("The client is now connected to the server.");
            SendConfirmationToClient();
            AwaitClientConfirmation();
        }

        protected void SendConfirmationToClient()
        {
            OscMessage message = new OscMessage();
            message.address = "/ServerConfirmation";
            this.osc.Send(message);
        }

        private void AwaitClientConfirmation()
        {
            osc.SetAddressHandler("/ClientConfirmation", ClientConfirmation);
        } 

        protected void ClientConfirmation(OscMessage message)
        {
            NetworkDebug.Log("Server is ready.");
            this.OnReady();
        }

        protected override void OnReady()
        {
            
            this.osc.Reset();
            base.Start();
            base.OnReady();
        }
    }
}
