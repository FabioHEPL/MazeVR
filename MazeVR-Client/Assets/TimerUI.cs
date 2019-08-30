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
     
        }

        private void Refresh()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timer.CurrentSeconds);
            timerText.text = timeSpan.ToString(@"mm\:ss");
        }

        private void OnEnable()
        {
            this.timer.Began += Timer_Began;
            this.timer.Tick += Timer_Tick;
        }

        private void OnDisable()
        {
            this.timer.Began -= Timer_Began;
            this.timer.Tick -= Timer_Tick;
        }

        private void Timer_Began()
        {
            
        }

        private void Timer_Tick()
        {
            this.Refresh();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}