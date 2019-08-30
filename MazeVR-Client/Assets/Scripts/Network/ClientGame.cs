using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class ClientGame : Game
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Ready()
        {

        }

        public void End(EndGame endGame)
        {
            OnEnded(new EndedArgs(endGame));
        }
    }
}