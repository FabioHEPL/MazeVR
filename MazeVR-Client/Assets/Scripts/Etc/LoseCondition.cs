using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class LoseCondition : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        [SerializeField]
        private ITimer timer;

        public event EventHandler<FulfilledArgs> Fulfilled;

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            //this.player.Death += Player_Death;
            //this.timer.TimeOut += Timer_TimeOut;
        }

        private void OnDisable()
        {
            //this.player.Death -= Player_Death;
            //this.timer.TimeOut -= Timer_TimeOut;
        }

        private void Player_Death(object sender, DeathArgs args)
        {
            this.Fulfill();
        }

        private void Timer_TimeOut(object sender, TimeOutArgs args)
        {
            this.Fulfill();
        }

        // OOD:
        // Should be a event, and other entities would do something about it
        public void Fulfill()
        {
            Debug.Log($"{this.name} : fulfilled");
            // display lose panel
            this.Fulfilled?.Invoke(this, new FulfilledArgs());
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log($"{this.name} : fulfilled");
                Fulfill();
            }
        }
    }

    public class FulfilledArgs : EventArgs
    {

    }
}