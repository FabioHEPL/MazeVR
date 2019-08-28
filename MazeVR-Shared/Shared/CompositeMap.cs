using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    [System.Serializable]
    public class NetworkBehaviourMap
    {
        [SerializeField]
        private string identifier;
        public string Identifier => this.identifier;

        [SerializeField]
        private NetworkBehaviour behaviour;
        public NetworkBehaviour Behaviour => this.behaviour;   

        public NetworkBehaviourMap(NetworkBehaviour behaviour, string identifier)
        {
            this.behaviour = behaviour;
            this.identifier = identifier;
        }
    }
}
