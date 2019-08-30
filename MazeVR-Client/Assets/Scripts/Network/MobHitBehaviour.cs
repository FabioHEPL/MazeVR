using MazeVR.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class MobHitBehaviour : NetworkBehaviour
    {
        [SerializeField]
        protected Vulnerable vulnerable;

        private void Awake()
        {
            this.vulnerable = GetComponent<Vulnerable>();
        }

        private void OnEnable()
        {
            this.vulnerable.Hit += Vulnerable_Hit;
        }

        private void OnDisable()
        {
            this.vulnerable.Hit -= Vulnerable_Hit;
        }


        private void Vulnerable_Hit()
        {
            NetworkDebug.Log("Sending hit reg to server...");
            this.OnUpdated(new NetworkBehaviourUpdatedArgs("Hit"));
        }


        public override void Synchronize(OscMessage message)
        {
            
        }
    }
}