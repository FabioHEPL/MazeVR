using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class Health : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        [SerializeField]
        private int value = 100;

        public void Decrease(int value)
        {
            this.value -= value;
        }
    }
}