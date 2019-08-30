using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class ServerTimer : NetworkBehaviour
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

        public event Action Began;
        public event Action Tick;

        // Start is called before the first frame update
        void Start()
        {
            this.Begin();
        }

        public void Begin()
        {
            StartCoroutine(BeginTick());
            this.Began?.Invoke();
        }

        protected IEnumerator BeginTick()
        {
            this.currentSeconds = this.seconds;
            while (currentSeconds >= 0)
            {
                yield return new WaitForSecondsRealtime(1);
                currentSeconds--;
                OnTick();
            }
        }

        protected void OnTick()
        {
            this.Tick?.Invoke();
            this.OnUpdated(new NetworkBehaviourUpdatedArgs("Tick", currentSeconds));
        }

        public override void Synchronize(OscMessage message)
        {

        }
    }
}