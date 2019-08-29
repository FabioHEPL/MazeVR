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

        // OOD:
        // Should be subscribed to Fulfilled event
        [SerializeField]
        private int LosePanel;

        private void OnEnable()
        {
            this.player.Death += Player_Death;
            this.timer.TimeOut += Timer_TimeOut;
        }

        private void OnDisable()
        {
            this.player.Death -= Player_Death;
            this.timer.TimeOut -= Timer_TimeOut;
        }

        private void Player_Death(object sender, DeathArgs args)
        {
            
        }

        private void Timer_TimeOut(object sender, TimeOutArgs args)
        {
            
        }

        // OOD:
        // Should be a event, and other entities would do something about it
        public void Fulfill()
        {
            // display lose panel
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