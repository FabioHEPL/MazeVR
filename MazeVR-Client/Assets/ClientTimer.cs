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
        private float seconds = 10;
        public float Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public override void Synchronize(OscMessage message)
        {
            switch (message.address)
            {
                case "Began":
                    OnBegan(message);
                    break;
            }
        }

        public event Action Began;

        public Action OnTick { get; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnBegan(OscMessage message)
        {
            this.seconds = message.GetFloat(1);
            this.Begin();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Begin()
        {
            StartCoroutine(StartTimer());
            this.Began?.Invoke();
        }

        protected IEnumerator StartTimer()
        {
            float currentTime = 0;
            while (currentTime < seconds)
            {
                currentTime += Time.deltaTime;
                OnTick();
                yield return null;
            }
        }

        protected void OnEnded()
        {

        }
    }

}
