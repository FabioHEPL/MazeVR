using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MazeVR.Client
{
    public class TimerUI : MonoBehaviour
    {
        public ClientTimer timer;

        [SerializeField]
        private Text timerText;

        private void Awake()
        {
            this.timer = FindObjectOfType<ClientTimer>();
        }

        private void Start()
        {
            timer.OnTick = () => this.Refresh();
        }

        private void Refresh()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timer.Seconds);
            timerText.text = timeSpan.ToString(@"mm\:ss");
        }

        private void OnEnable()
        {
            this.timer.Began += Timer_Began;
        }

        private void OnDisable()
        {
            this.timer.Began -= Timer_Began;
        }

        private void Timer_Began()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}