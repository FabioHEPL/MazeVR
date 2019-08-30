using MazeVR.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class ServerGame : MonoBehaviour
    {
        [SerializeField]
        private LoseCondition loseCondition;

        public event EventHandler<EndedArgs> Ended;

        private void OnEnable()
        {
            this.loseCondition.Fulfilled += LoseCondition_Fulfilled;
        }

        private void OnDisable()
        {
            this.loseCondition.Fulfilled -= LoseCondition_Fulfilled;
        }

        private void LoseCondition_Fulfilled(object sender, FulfilledArgs args)
        {
            End();
        }

        private void End()
        {
            Debug.Log($"{this.name} : end");
            OnEnd();
        }

        private void OnEnd()
        {
            this.Ended?.Invoke(this, new EndedArgs());
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public class EndedArgs : EventArgs
        {

        }
    }
}