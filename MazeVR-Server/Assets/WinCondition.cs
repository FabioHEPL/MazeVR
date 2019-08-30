using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField]
        private VictoryZone victoryZone;

        [SerializeField]
        //private string VictoryZoneTag = true;

        public event EventHandler<FulfilledArgs> Fulfilled;

        private void OnEnable()
        {
            this.victoryZone.PlayerEntered += VictoryZone_PlayerEntered;
            //this.timer.TimeOut += Timer_TimeOut;
        }

        private void OnDisable()
        {
            this.victoryZone.PlayerEntered -= VictoryZone_PlayerEntered;
            //this.timer.TimeOut -= Timer_TimeOut;
        }

        private void VictoryZone_PlayerEntered(object sender, VictoryZone.EnteredArgs e)
        {
            Fulfill();
        }

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

        }
    }
}