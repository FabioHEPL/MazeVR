using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class AutoRegister : MonoBehaviour
    {
        public Network network;
        public NetworkBehaviour behaviour;
        public int priority = 1;

        private void Awake()
        {
            network = GameObject.FindObjectOfType<Network>();
            behaviour = GetComponent<NetworkBehaviour>();
        }

        private void Start()
        {
            network.Register(behaviour.Entity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
