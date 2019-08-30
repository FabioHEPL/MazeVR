using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class ClientTimer : NetworkBehaviour
    {
        [SerializeField]
        private int seconds = 10;
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        [SerializeField]
        private int currentSeconds = 0;
        public int CurrentSeconds
        {
            get { return currentSeconds; }
            set { currentSeconds = value; }
        }

        public override void Synchronize(OscMessage message)
        {
            switch (message.address)
            {
                case "Began":
                    OnBegan(message);
                    break;
                case "Tick":
                    OnTick(message);
                    break;
            }
        }

        public event Action Began;
        public event Action Tick;

        //public Action OnTick { get; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnBegan(OscMessage message)
        {
            //this.seconds = message.GetFloat(1);
            
        }

        
        protected void OnTick(OscMessage message)
        {
            currentSeconds = message.GetInt(1);
            this.Tick?.Invoke();
        }
    }

}
