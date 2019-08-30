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
        private float totalSeconds;
        public float TotalSeconds
        {
            get { return totalSeconds; }
            set { totalSeconds = value; }
        }

        public Action OnStart { get; set; }
        public Action OnEnd { get; set; }
        public Action<float> OnTick { get; set; }        

        public void Begin()
        {
            OnBegan();
        }

        private void OnBegan()
        {


            OnUpdated(new NetworkBehaviourUpdatedArgs("Began", totalSeconds));
        }

        //private void OnTick()
        //{

        //}

        public override void Synchronize(OscMessage message)
        {
            
        }

        //public void Begin()
        //{
        //    StartCoroutine(StartTimer());
        //    this.Began?.Invoke();
        //}

        protected IEnumerator StartTimer()
        {
            float currentTime = 0;
            while (currentTime < totalSeconds)
            {
                currentTime += Time.deltaTime;
                //OnTick();
                yield return null;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}