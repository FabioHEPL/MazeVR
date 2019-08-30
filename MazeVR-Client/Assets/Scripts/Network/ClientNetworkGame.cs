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
        [SerializeField]
        private ClientGame game;

        public event Action Connected;
        public event Action Started;
        public event Action Ended;

        private void Awake()
        {
            game.gameObject.SetActive(false);
        }

        private void Start()
        {
            
        }

        public override void Synchronize(OscMessage message)
        {
            switch (message.address)
            {
                case "Connected":
                    this.OnConnected();
                    break;
                case "Started":
                    this.OnStarted();
                    break;
                case "Ended":
                    this.OnEnded();
                    break;
                default:
                    break;
            }

            //Debug.Log($"Game : {message}");

            //// detecter si victoire ou defaite
            //int endGameInt = message.GetInt(1);

            //EndGame endGame = (EndGame)endGameInt;

            //// 0 : defaite, 1 : victoire
            //game.End(endGame);
        }

        private void OnStarted()
        {
            Debug.Log("Game Started !");
            this.Started?.Invoke();
   
        }

        private void OnConnected()
        {
            Debug.Log($"Game Connected !");
            this.Connected?.Invoke();
          
        }

        private void OnEnded()
        {
            Debug.Log($"Game Ended !");
            this.Connected?.Invoke();
        }
    }
}

