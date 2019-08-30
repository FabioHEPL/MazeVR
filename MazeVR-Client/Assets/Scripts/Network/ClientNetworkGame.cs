using MazeVR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Client
{
    public class ClientNetworkGame : NetworkBehaviour
    {


        public event Action Connected;
        public event EventHandler<StartedArgs> Started;
        public event EventHandler<EndedArgs> Ended;

        private void Awake()
        {
            //game.gameObject.SetActive(false);
        }

        private void Start()
        {
            
        }

        public override void Synchronize(OscMessage message)
        {
            switch (message.address)
            {
                case "Connected":
                    this.OnConnected(message);
                    break;
                case "Started":
                    this.OnStarted(message);
                    break;
                case "Ended":
                    this.OnEnded(message);
                    break;
                default:
                    break;
            }


        }

        private void OnStarted(OscMessage message)
        {
            Debug.Log("Game Started !");
            this.Started?.Invoke(this, new StartedArgs());   
        }

        private void OnConnected(OscMessage message)
        {
            Debug.Log($"Game Connected !");
            this.Connected?.Invoke();
          
        }

        private void OnEnded(OscMessage message)
        {
            // detecter si victoire ou defaite
            int endGameInt = message.GetInt(1);

            EndGame endGame = (EndGame)endGameInt;

            Debug.Log($"Game Ended !");
            this.Ended?.Invoke(this, new EndedArgs(endGame));
        }
    }

    public class EndedArgs : EventArgs
    {
        private EndGame endGame;
        public EndGame EndGame => this.endGame;

        public EndedArgs(EndGame endGame)
        {
            this.endGame = endGame;
        }
    }

    public class StartedArgs : EventArgs
    {
        //private EndGame endGame;
        //public EndGame EndGame => this.endGame;

        public StartedArgs()
        {
            //this.endGame = endGame;
        }
    }
}

