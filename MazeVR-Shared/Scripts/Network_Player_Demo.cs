using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR_Shared
{
    public class Network_Player_Demo : MonoBehaviour
    {
        private OSC osc;

        private void Awake()
        {
            this.osc = FindObjectOfType<OSC>();
        }

        // Start is called before the first frame update
        void Start()
        {
            osc.SetAddressHandler("/PositionUpdate", NetworkPlayer_UpdatePosition);
            Debug.Log("setting address handler to position update");
        }

        private void NetworkPlayer_UpdatePosition(OscMessage message)
        {
            float x = message.GetFloat(0);
            float y = message.GetFloat(1);
            float z = message.GetFloat(2);

            Debug.Log("received position");

            transform.position = new Vector3(x, y, z);
        }
    }
}