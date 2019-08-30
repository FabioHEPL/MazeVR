using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private float seconds;
        public float Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public Action OnStart { get; set; }
        public Action OnEnd { get; set; }
        public Action<float> OnTick { get; set; }


        public void Begin()
        {
            
        }
    }
}
