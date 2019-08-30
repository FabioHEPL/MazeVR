using MazeVR.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class Player : MonoBehaviour, IPlayer
    {
        public event EventHandler<DeathArgs> Death;
        public event EventHandler<TriggerEnteredArgs> TriggerEntered;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            this.TriggerEntered?.Invoke(this, new TriggerEnteredArgs(other));
        }
    }

    public class TriggerEnteredArgs : EventArgs
    {
        private Collider other;
        public Collider Other => other;

        public TriggerEnteredArgs(Collider other)
        {
            this.other = other;
        }
    }
}